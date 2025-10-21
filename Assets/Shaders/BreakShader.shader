Shader "Custom/PixelCrackEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        
        [Header(Crack Settings)]
        _CrackAmount ("Crack Amount", Range(0, 1)) = 0
        _CrackDensity ("Crack Density", Range(1, 20)) = 8
        _CrackThickness ("Crack Thickness", Range(0.01, 0.2)) = 0.05
        _CrackColor ("Crack Color", Color) = (0, 0, 0, 1)
        
        [Header(Pixel Settings)]
        _PixelSize ("Pixel Size", Range(1, 100)) = 32
        
        [Header(Hit Point)]
        _HitPoint ("Hit Point (XY)", Vector) = (0.5, 0.5, 0, 0)
        _HitRadius ("Hit Radius", Range(0, 2)) = 0.8
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _CrackAmount;
            float _CrackDensity;
            float _CrackThickness;
            fixed4 _CrackColor;
            float _PixelSize;
            float4 _HitPoint;
            float _HitRadius;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            // 해시 함수
            float hash12(float2 p)
            {
                float3 p3 = frac(float3(p.xyx) * 0.1031);
                p3 += dot(p3, p3.yzx + 33.33);
                return frac((p3.x + p3.y) * p3.z);
            }
            
            float2 hash22(float2 p)
            {
                float3 p3 = frac(float3(p.xyx) * float3(0.1031, 0.1030, 0.0973));
                p3 += dot(p3, p3.yzx + 33.33);
                return frac((p3.xx + p3.yz) * p3.zy);
            }
            
            // 픽셀화 함수
            float2 pixelate(float2 uv, float pixelSize)
            {
                float2 pixelUV = floor(uv * pixelSize) / pixelSize;
                return pixelUV;
            }
            
            // 금 간 패턴 생성
            float crackPattern(float2 uv, float density, float thickness, float2 hitPoint, float hitRadius)
            {
                float2 pixelUV = pixelate(uv, _PixelSize);
                
                // 히트 포인트로부터의 거리
                float distToHit = length(uv - hitPoint);
                float hitMask = smoothstep(hitRadius, 0.0, distToHit);
                
                if(hitMask < 0.01) return 0.0;
                
                float crack = 0.0;
                
                // 격자 기반 균열
                float2 grid = pixelUV * density;
                float2 gridID = floor(grid);
                float2 gridUV = frac(grid);
                
                // 랜덤 균열 방향
                float rand = hash12(gridID);
                
                // 방사형 균열 (히트 포인트에서 퍼져나감)
                float2 toHit = normalize(pixelUV - hitPoint);
                float angle = atan2(toHit.y, toHit.x);
                float angleSnap = floor(angle / 0.5) * 0.5; // 픽셀스럽게 각도 스냅
                
                // 균열 라인 생성
                if(rand < _CrackAmount)
                {
                    // 수평/수직 균열
                    float hLine = step(0.5 - thickness, gridUV.y) * step(gridUV.y, 0.5 + thickness);
                    float vLine = step(0.5 - thickness, gridUV.x) * step(gridUV.x, 0.5 + thickness);
                    
                    // 대각선 균열
                    float diag1 = abs(gridUV.x - gridUV.y);
                    float diag2 = abs(gridUV.x - (1.0 - gridUV.y));
                    float dLine1 = step(diag1, thickness * 2.0);
                    float dLine2 = step(diag2, thickness * 2.0);
                    
                    crack = max(crack, hLine + vLine + dLine1 + dLine2);
                }
                
                // 메인 방사형 균열 (히트 포인트에서 뻗어나감)
                float radialCrack = 0.0;
                for(int i = 0; i < 8; i++)
                {
                    float rayAngle = float(i) * 0.785398; // 45도 간격
                    float2 rayDir = float2(cos(rayAngle), sin(rayAngle));
                    float2 toRay = pixelUV - hitPoint;
                    float distToRay = abs(toRay.x * rayDir.y - toRay.y * rayDir.x);
                    
                    float rayMask = step(distToRay, thickness * 3.0);
                    rayMask *= smoothstep(hitRadius, 0.1, distToHit);
                    radialCrack = max(radialCrack, rayMask);
                }
                
                crack = max(crack, radialCrack * hitMask);
                
                return saturate(crack);
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // 픽셀화된 UV
                float2 pixelUV = pixelate(i.uv, _PixelSize);
                
                // 베이스 텍스처
                fixed4 col = tex2D(_MainTex, pixelUV) * _Color;
                
                // 균열 생성
                float crack = crackPattern(i.uv, _CrackDensity, _CrackThickness, _HitPoint.xy, _HitRadius);
                
                // 균열 색상 적용
                col.rgb = lerp(col.rgb, _CrackColor.rgb, crack);
                
                // 균열 주변 어둡게
                float crackShadow = crack * 0.5;
                col.rgb *= (1.0 - crackShadow);
                
                return col;
            }
            ENDCG
        }
    }
}
