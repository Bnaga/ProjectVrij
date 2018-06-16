// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Hidden/wiggleKelpRenderTex" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0)
        _MainTex ("Main Texture", 2D) = "white" {}
        _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        _HalfOverCutoff ("0.5 / Alpha cutoff", Range(0,1)) = 1.0
        _BaseLight ("Base Light", Range(0, 1)) = 0.35
        _AO ("Amb. Occlusion", Range(0, 10)) = 2.4
        _Occlusion ("Dir Occlusion", Range(0, 20)) = 7.5
          [Header(Animation)]
        _Speed("Speed", Range( 0 , 10)) = 0
		_Scale("Scale", Range( 0 , 1)) = 0.33
		_Yaw("Yaw", Float) = 0.5
		_Roll("Roll", Float) = 0.5
        // These are here only to provide default values
        [HideInInspector] _TreeInstanceColor ("TreeInstanceColor", Vector) = (1,1,1,1)
        [HideInInspector] _TreeInstanceScale ("TreeInstanceScale", Vector) = (1,1,1,1)
        [HideInInspector] _SquashAmount ("Squash", Float) = 1
    }
    SubShader {

        Tags { "Queue" = "AlphaTest" }
        Cull Off

        Pass {
            Lighting On
            ZWrite On

            CGPROGRAM
            #pragma vertex leaves
            #pragma fragment frag
            #define USE_CUSTOM_LIGHT_DIR 1
            #include "UnityBuiltin2xTreeLibrary.cginc"

            sampler2D _MainTex;
            fixed _Cutoff;

            uniform float _Speed;
			uniform float _Yaw;
			uniform float _Roll;
			uniform float _Scale;
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
				fixed4 color : COLOR;
                UNITY_FOG_COORDS(2)
            };
			            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

			 VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float3 ase_vertex3Pos = v.vertex.xyz;
			v.vertex.xyz += ( ( sin( ( ( (_Time.w) * _Speed) + ( ase_vertex3Pos.z * _Yaw ) + ( ase_vertex3Pos.y * _Roll ) )+ v.vertex.y*_Yaw ) * _Scale ) * float3(1,0,0) );
                v.vertex.xyz += ( ( cos( ( ( (_Time.w) * _Speed/_Roll) + ( ase_vertex3Pos.z * _Yaw ) + ( ase_vertex3Pos.y * _Roll ) ) ) * _Scale ) * float3(1,0,0) );
           
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.uv = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }



            fixed4 frag(VertexOutput input) : SV_Target
            {
                fixed4 col = tex2D( _MainTex, input.uv.xy);
                col.rgb *= input.color.rgb;
                clip(col.a - _Cutoff);
                col.a = 1;
                return col;
            }
            ENDCG
        }
    }

    Fallback Off
}
