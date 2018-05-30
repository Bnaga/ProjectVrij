// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "JASPERWATER" {
    Properties {
        [NoScaleOffset]_SmallWavesTexture ("Small Waves Texture", 2D) = "bump" {}
        _Intensity ("Intensity", Range(0, 50)) = 0
    }
    SubShader {
        GrabPass { "_GrabTexture" }
 
        Pass {
            Tags { "Queue"="Transparent" }
       
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
                        #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
 
            struct v2f {
                half4 pos : SV_POSITION;
                half4 grabPos : TEXCOORD0;
            };
 
            sampler2D _GrabTexture;
            half _Intensity;
            sampler2D _SmallWavesTexture;

            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
                float4 projPos : TEXCOORD6;
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                o.screenPos = o.pos;
                return o;
            }

            v2f vert(appdata_base v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.pos);
                return o;
            }
 
            half4 frag(VertexOutput i) : COLOR {
                i.uv0.x += sin((_Time.y + i.uv0.y) * _Intensity)/20;
                fixed4 color = tex2D(_GrabTexture, i.uv0);
                fixed4 output = color * tex2D(_SmallWavesTexture, color);
                return output;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}