
Shader "Fogwall"
{
	Properties
	{
		_Color ("Color", Color) = (0.5,0.5,0.5,1)
		_GradBot ("Gradient Bottom", Float) = 0
		_GradTop ("Gradient Top", Float) = 1


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
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float3 worldPos : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};
			float4 _Color;
			float _GradBot;
			float _GradTop;
			
			v2f vert(appdata v) {
                  v2f o;
                  o.worldPos = mul (unity_ObjectToWorld, v.vertex);
                  o.vertex = UnityObjectToClipPos(v.vertex);

                  return o;
              }
  
              fixed4 frag(v2f i) : SV_Target {
                  fixed4 col = _Color;
				  float3 pos = i.worldPos;
				  
                  //col.a = pos.z + _GradBot;
				  col.a=1/2;
                  return col;
              }
			ENDCG
		}
	}

}
