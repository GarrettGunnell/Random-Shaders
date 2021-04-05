Shader "Hidden/Modulus" {
    
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    
    SubShader {
        Cull Off ZWrite Off ZTest Always

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma target 5.0

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v) {
                v2f f;
                f.vertex = UnityObjectToClipPos(v.vertex);
                f.uv = v.uv;

                return f;
            }

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            int radius;

            fixed4 frag(v2f f) : SV_Target {
                fixed4 col = 0;
                int x = (f.uv.x * _MainTex_TexelSize.z) / 2;
                int y = (f.uv.y * _MainTex_TexelSize.w) / 2;
                
                if ((x & y) & radius) {
                    col.r = 63.0 / 255.0;
                    col.g = 171.0 / 255.0;
                    col.b = 147.0 / 255.0;
                } else {
                    col.r = 228.0 / 255.0;
                    col.g = 193.0 / 255.0;
                    col.b = 177.0 / 255.0;
                }

                return col;
            }
            ENDCG
        }
    }
}
