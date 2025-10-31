Shader "Custom/SpriteHologram_Unscaled"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint Color", Color) = (0, 1, 1, 1)
        _HoloColor ("Hologram Color", Color) = (0, 1, 1, 1)
        
        _ScanlineSpeed ("Scanline Speed", Float) = 1.0
        _ScanlineWidth ("Scanline Width", Range(0.01, 0.5)) = 0.1
        _ScanlineIntensity ("Scanline Intensity", Range(0, 1)) = 0.3
        
        _GlitchIntensity ("Glitch Intensity", Range(0, 1)) = 0.2
        _GlitchSpeed ("Glitch Speed", Float) = 5.0
        
        _RimPower ("Rim Power", Range(0.5, 8.0)) = 3.0
        _RimIntensity ("Rim Intensity", Range(0, 2)) = 1.0
        
        _FlickerSpeed ("Flicker Speed", Float) = 10.0
        _FlickerIntensity ("Flicker Intensity", Range(0, 1)) = 0.1
        
        _Alpha ("Alpha", Range(0, 1)) = 0.8
        
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }

    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _HoloColor;
            
            float _ScanlineSpeed;
            float _ScanlineWidth;
            float _ScanlineIntensity;
            
            float _GlitchIntensity;
            float _GlitchSpeed;
            
            float _RimPower;
            float _RimIntensity;
            
            float _FlickerSpeed;
            float _FlickerIntensity;
            
            float _Alpha;
            
            float _UnscaledTime;
            
            float rand(float2 co)
            {
                return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
            }

            v2f vert(appdata_t v)
            {
                v2f o;
                
                float glitch = rand(floor(_UnscaledTime * _GlitchSpeed)) * _GlitchIntensity;
                if (rand(float2(_UnscaledTime, 0)) > 0.9)
                {
                    v.vertex.x += glitch * 0.1;
                }
                
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.color = v.color * _Color;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                #ifdef PIXELSNAP_ON
                o.vertex = UnityPixelSnap(o.vertex);
                #endif
                
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, i.texcoord) * i.color;
                
                float scanline = frac(i.texcoord.y * 10.0 + _UnscaledTime * _ScanlineSpeed);
                scanline = smoothstep(_ScanlineWidth, 0, abs(scanline - 0.5));
                
                float flicker = 1.0 - _FlickerIntensity * rand(floor(_UnscaledTime * _FlickerSpeed));
                
                float2 texelSize = float2(0.01, 0.01);
                float alphaUp = tex2D(_MainTex, i.texcoord + float2(0, texelSize.y)).a;
                float alphaDown = tex2D(_MainTex, i.texcoord - float2(0, texelSize.y)).a;
                float alphaLeft = tex2D(_MainTex, i.texcoord - float2(texelSize.x, 0)).a;
                float alphaRight = tex2D(_MainTex, i.texcoord + float2(texelSize.x, 0)).a;
                
                float edgeDetect = c.a - min(min(alphaUp, alphaDown), min(alphaLeft, alphaRight));
                float rim = pow(edgeDetect, _RimPower) * _RimIntensity;
                
                c.rgb = lerp(c.rgb, _HoloColor.rgb, 0.5);
                
                c.rgb += scanline * _ScanlineIntensity * _HoloColor.rgb;
                c.rgb += rim * _HoloColor.rgb;
                c.rgb *= flicker;
                c.a *= _Alpha * flicker;
                
                clip(c.a - 0.01);
                
                return c;
            }
            ENDCG
        }
    }
    
    Fallback "Sprites/Default"
}
