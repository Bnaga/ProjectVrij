// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

 Shader "Custom/BackgroundKelp" {
     Properties {
         _Color ("Color", Color) = (1,1,1,1)
         _MainTex ("Albedo (RGB)", 2D) = "white" {}
         _Glossiness ("Smoothness", Range(0,1)) = 0.5
         _Metallic ("Metallic", Range(0,1)) = 0.0
		_BaseHeight ("BaseHeight", Float) = 0

           [Header(Animation)]
        _Speed("Speed", Range( 0 , 10)) = 0
		_Scale("Scale", Range( 0 , 1)) = 0.33
		_Yaw("Yaw", Float) = 0.5
		_Roll("Roll", Float) = 0.5
     }
     SubShader {
         Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
         LOD 200
         Cull Back
 
         CGPROGRAM
             // Physically based Standard lighting model, and enable shadows on all light types
         #pragma surface surf Standard fullforwardshadows alpha vertex:vert
 
         #pragma target 3.0
 
         sampler2D _MainTex;
 
         struct Input {
             float2 uv_MainTex;
         };
        uniform half _Glossiness;
        uniform half _Metallic;
        uniform fixed4 _Color;

		uniform float _BaseHeight;
    
        uniform float _Speed;
		uniform float _Yaw;
		uniform float _Roll;
		uniform float _Scale;


         void vert (inout appdata_full v){
            float3 ase_vertex3Pos = v.vertex.xyz;
           float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
            v.vertex.xyz += ( ( sin( ( ( (_Time.w) * _Speed) + ( ase_vertex3Pos.z * _Yaw ) + ( ase_vertex3Pos.y * _Roll ) )+ v.vertex.y*_Yaw ) * _Scale ) * float3(1,0,0) ) * (worldPos.y + _BaseHeight);
            
         }
       
 
         void surf (Input IN, inout SurfaceOutputStandard o) {
             // Albedo comes from a texture tinted by color
             fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
             
             o.Albedo = c.rgb;
             // Metallic and smoothness come from slider variables
             o.Metallic = _Metallic;
             o.Smoothness = _Glossiness;
             o.Alpha = c.a;
         }
         ENDCG
 
         Cull Front
 
         CGPROGRAM
             // Physically based Standard lighting model, and enable shadows on all light types
         #pragma surface surf Standard fullforwardshadows alpha
 
         #pragma target 3.0
         #pragma vertex vert
 
         sampler2D _MainTex;
 
         struct Input {
             float2 uv_MainTex;
         };
 
         uniform half _Glossiness;
        uniform half _Metallic;
        uniform fixed4 _Color;
    
		uniform float _BaseHeight;

        uniform float _Speed;
		uniform float _Yaw;
		uniform float _Roll;
		uniform float _Scale;
 
         void vert (inout appdata_full v) {
             float3 ase_vertex3Pos = v.vertex.xyz;
             float3 worldPos = mul(unity_ObjectToWorld, v.vertex);
            v.vertex.xyz += ( ( sin( ( ( (_Time.w) * _Speed) + ( ase_vertex3Pos.z * _Yaw ) + ( ase_vertex3Pos.y * _Roll ) )+ v.vertex.y*_Yaw ) * _Scale ) * float3(1,0,0) ) * (worldPos.y + _BaseHeight);
            v.normal *= -1;
         }
 
         void surf (Input IN, inout SurfaceOutputStandard o) {
             // Albedo comes from a texture tinted by color
             fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
             o.Albedo = c.rgb;
             // Metallic and smoothness come from slider variables
             o.Metallic = _Metallic;
             o.Smoothness = _Glossiness;
             o.Alpha = c.a;
         }
         ENDCG
     }
     FallBack "Transparent/Cutout/VertexLit"
 }