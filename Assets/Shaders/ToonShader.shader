Shader "Custom/ToonShader"
{
    Properties
    {
        _InnerColor ("Inner Color", Color) = (1, 1, 1, 1)
        _OuterColor ("Outer Color", Color) = (0.3, 0.3, 0.3, 1)
        _Threshold ("Threshold", Range(0, 1)) = 0.5
        _Smoothness ("Smoothness", Range(0, 0.5)) = 0.05
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 200
        
        Pass
        {
            Cull Back
            ZWrite On
            ZTest LEqual
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            
            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
            };
            
            fixed4 _InnerColor;
            fixed4 _OuterColor;
            float _Threshold;
            float _Smoothness;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float3 normal = normalize(i.worldNormal);
                float3 viewDir = normalize(_WorldSpaceCameraPos - mul(unity_ObjectToWorld, float4(0,0,0,1)).xyz);
                
                float fresnel = 1.0 - abs(dot(normal, viewDir));
                float toonValue = smoothstep(_Threshold - _Smoothness, _Threshold + _Smoothness, fresnel);
                
                fixed4 finalColor = lerp(_InnerColor, _OuterColor, toonValue);
                
                return finalColor;
            }
            ENDCG
        }
    }
    
    FallBack "Diffuse"
}