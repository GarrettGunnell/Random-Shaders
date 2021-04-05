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

            fixed4 frag(v2f f) : SV_Target {
                fixed4 col = 0;
                int x = f.uv.x * _MainTex_TexelSize.z;
                int y = f.uv.y * _MainTex_TexelSize.w;

                if (x % 2 == 0)
                    col.r = 1;
                
                return col;
            }
            ENDCG
        }
    }
}
