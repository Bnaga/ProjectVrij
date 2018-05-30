Shader "JasperWATER2" {
    Properties {
        [NoScaleOffset]_SmallWavesTexture ("Small Waves Texture", 2D) = "bump" {}
        _SmallWavesTiling ("Small Waves Tiling", Float ) = 1
        _SmallWavesSpeed ("Small Waves Speed", Float ) = -20
        _SmallWaveRrefraction ("Small Wave Rrefraction", Range(0, 3)) = 2.2
        [NoScaleOffset]_MediumWavesTexture ("Medium Waves Texture", 2D) = "bump" {}
        _MediumWavesTiling ("Medium Waves Tiling", Float ) = 0.5
        _MediumWavesSpeed ("Medium Waves Speed", Float ) = 40
        _MediumWaveRefraction ("Medium Wave Refraction", Range(0, 3)) = 1.8
        [NoScaleOffset]_LargeWavesTexture ("Large Waves Texture", 2D) = "bump" {}
        _LargeWavesTiling ("Large Waves Tiling", Float ) = 0.3
        _LargeWavesSpeed ("Large Waves Speed", Float ) = -40
        _LargeWaveRefraction ("Large Wave Refraction", Range(0, 3)) = 1.5
        _MainColor ("Main Color", Color) = (0,0.4627451,1,1)
        _DeepWaterColor ("Deep Water Color", Color) = (0,0.3411765,0.6235294,1)
        _Fade ("Fade", Float ) = 1.45
        _Density ("Density", Range(0, 10)) = 1.74
        _DepthTransparency ("Depth Transparency", Float ) = 1.5
        _ShoreFade ("Shore Fade", Float ) = 0.3
        _ShoreTransparency ("Shore Transparency", Float ) = 0.04
        _WaveBlend ("Wave Blend", Float ) = 0.77
        _WaveFade ("Wave Fade", Float ) = 1.19
        [MaterialToggle] _EnableReflections ("Enable Reflections", Float ) = 0
        _ReflectionIntensity ("Reflection Intensity", Range(0, 1)) = 0.5
        _Distortion ("Distortion", Range(0, 2)) = 0.3
        _Specular ("Specular", Float ) = 1
        _Gloss ("Gloss", Range(0, 1)) = 0.55
        _LightWrapping ("Light Wrapping", Float ) = 0
        [HideInInspector]_ReflectionTex ("Reflection Tex", 2D) = "white" {}
        [NoScaleOffset]_FoamTexture ("Foam Texture", 2D) = "white" {}
        _FoamTiling ("Foam Tiling", Float ) = 3
        _FoamBlend ("Foam Blend", Float ) = 0.15
        _FoamVisibility ("Foam Visibility", Range(0, 1)) = 0.3
        _FoamIntensity ("Foam Intensity", Float ) = 10
        _FoamContrast ("Foam Contrast", Range(0, 0.5)) = 0.25
        _FoamColor ("Foam Color", Color) = (0.3823529,0.3879758,0.3879758,1)
        _FoamSpeed ("Foam Speed", Float ) = 120
        _FoamDistFalloff ("Foam Dist. Falloff", Float ) = 16
        _FoamDistFade ("Foam Dist. Fade", Float ) = 9.5
        [MaterialToggle] _UnderwaterMode ("Underwater Mode", Float ) = 0
        [MaterialToggle] _EnableCustomFog ("Enable Custom Fog", Float ) = 3.654843
        _FogColor ("Fog Color", Color) = (1,1,1,1)
        _FogDistance ("Fog Distance", Float ) = 1000
        _FogFade ("Fog Fade", Float ) = 1
        _FlowMap ("Flow Map", 2D) = "white" {}
        _FlowSpeed ("Flow Speed", Float ) = 5
        [MaterialToggle] _UsingLinearColorSpace ("Using Linear Color Space", Float ) = 0
        _MediumTilingDistance ("Medium Tiling Distance", Float ) = 50
        _DistanceTilingFade ("Distance Tiling Fade", Float ) = 1
        _LongTilingDistance ("Long Tiling Distance", Float ) = 200
        _RefractionDistance ("Refraction Distance", Float ) = 0
        _RefractionFalloff ("Refraction Falloff", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 128
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform float _Gloss;
            uniform float _SmallWaveRrefraction;
            uniform float _Density;
            uniform float4 _MainColor;
            uniform float _Fade;
            uniform float4 _DeepWaterColor;
            uniform float _SmallWavesSpeed;
            uniform float _SmallWavesTiling;
            uniform sampler2D _ReflectionTex; uniform float4 _ReflectionTex_ST;
            uniform float _ReflectionIntensity;
            uniform fixed _EnableReflections;
            uniform float _MediumWavesTiling;
            uniform float _MediumWavesSpeed;
            uniform float _MediumWaveRefraction;
            uniform float _LargeWaveRefraction;
            uniform float _LargeWavesTiling;
            uniform float _LargeWavesSpeed;
            uniform float _DepthTransparency;
            uniform float _FoamBlend;
            uniform float4 _FoamColor;
            uniform float _FoamIntensity;
            uniform float _FoamContrast;
            uniform sampler2D _FoamTexture;
            uniform float _FoamSpeed;
            uniform float _FoamTiling;
            uniform float _FoamDistFalloff;
            uniform float _FoamDistFade;
            uniform float _FoamVisibility;
            uniform fixed _UnderwaterMode;
            uniform float _ShoreFade;
            uniform float _ShoreTransparency;
            uniform float _LightWrapping;
            uniform float _Specular;
            uniform float _Distortion;
            uniform fixed _EnableCustomFog;
            uniform float4 _FogColor;
            uniform float _FogDistance;
            uniform float _FogFade;
            uniform sampler2D _FlowMap; uniform float4 _FlowMap_ST;
            uniform float _FlowSpeed;
            uniform sampler2D _SmallWavesTexture;
            uniform sampler2D _LargeWavesTexture;
            uniform sampler2D _MediumWavesTexture;
            uniform float _MediumTilingDistance;
            uniform float _DistanceTilingFade;
            uniform float _LongTilingDistance;
            uniform float _RefractionDistance;
            uniform float _RefractionFalloff;
            uniform fixed _UsingLinearColorSpace;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float _value1 = 1000.0;
                float2 _division1 = ((objScale.rb*_SmallWavesTiling)/_value1);
                float4 _timer1 = _Time + _TimeEditor;
                float2 _smallWavesPanner = (i.uv0+(float3((_SmallWavesSpeed/_division1),0.0)*(_timer1.r/100.0)));
                float4 _FlowMap_var = tex2D(_FlowMap,TRANSFORM_TEX(i.uv0, _FlowMap));
                float2 _flowReMap = ((lerp( _FlowMap_var.rgb, pow(_FlowMap_var.rgb,(1.0/2.2)), _UsingLinearColorSpace ).rg*1.0+-0.5)*(_FlowSpeed*(-1.0)));
                float4 _flowMapTimer = _Time + _TimeEditor;
                float _flowMapTimeRead = frac(_flowMapTimer.r);
                float2 _flowMapStretch1 = (_flowReMap*_flowMapTimeRead);
                float2 node_1318 = (_smallWavesPanner+_flowMapStretch1);
                float2 _multiplier2 = (node_1318*_division1);
                float3 _SmallWavesTexNF = UnpackNormal(tex2D(_SmallWavesTexture,_multiplier2));
                float _flowMapLerpValue = 0.5;
                float2 _flowMapStretch2 = (_flowReMap*frac((_flowMapTimer.r+_flowMapLerpValue)));
                float2 node_7539 = (_smallWavesPanner+_flowMapStretch2);
                float2 _multiplier11 = (node_7539*_division1);
                float3 _SmallWavesTexF = UnpackNormal(tex2D(_SmallWavesTexture,_multiplier11));
                float _flowMapLerpControl = abs(((_flowMapLerpValue-_flowMapTimeRead)/_flowMapLerpValue));
                float node_5721 = _flowMapLerpControl;
                float node_4306 = 10.0;
                float2 node_5474 = (_division1/node_4306);
                float2 node_4962 = (node_1318*node_5474);
                float3 _node_8854 = UnpackNormal(tex2D(_SmallWavesTexture,node_4962));
                float2 node_250 = (node_7539*node_5474);
                float3 _node_9704 = UnpackNormal(tex2D(_SmallWavesTexture,node_250));
                float node_4017 = distance(i.posWorld.rgb,_WorldSpaceCameraPos);
                float node_7914 = saturate(pow((node_4017/_MediumTilingDistance),_DistanceTilingFade));
                float node_1864 = 20.0;
                float2 node_3689 = (_division1/node_1864);
                float2 node_6944 = (node_1318*node_3689);
                float3 _node_8853 = UnpackNormal(tex2D(_SmallWavesTexture,node_6944));
                float2 node_9312 = (node_7539*node_3689);
                float3 _node_1159 = UnpackNormal(tex2D(_SmallWavesTexture,node_9312));
                float node_7910 = saturate(pow((node_4017/_LongTilingDistance),_DistanceTilingFade));
                float2 _division2 = ((objScale.rb*_MediumWavesTiling)/_value1);
                float4 _timer2 = _Time + _TimeEditor;
                float2 _mediumWavesPanner = (i.uv0+(float3((_MediumWavesSpeed/_division2),0.0)*(_timer2.r/100.0)));
                float2 node_8155 = (_mediumWavesPanner+_flowMapStretch1);
                float2 _multiplier3 = (node_8155*_division2);
                float3 _node_839 = UnpackNormal(tex2D(_MediumWavesTexture,_multiplier3));
                float2 node_3329 = (_mediumWavesPanner+_flowMapStretch2);
                float2 node_2709 = (node_3329*_division2);
                float3 _MediumWavesTexF = UnpackNormal(tex2D(_MediumWavesTexture,node_2709));
                float2 node_2866 = (_division2/node_4306);
                float2 node_1497 = (node_8155*node_2866);
                float3 _node_8779 = UnpackNormal(tex2D(_MediumWavesTexture,node_1497));
                float2 node_1477 = (node_3329*node_2866);
                float3 _node_1067 = UnpackNormal(tex2D(_MediumWavesTexture,node_1477));
                float2 node_2018 = (_division2/node_1864);
                float2 node_4729 = (node_8155*node_2018);
                float3 _node_4307 = UnpackNormal(tex2D(_MediumWavesTexture,node_4729));
                float2 node_9293 = (node_3329*node_2018);
                float3 _node_5369 = UnpackNormal(tex2D(_MediumWavesTexture,node_9293));
                float2 _division3 = ((objScale.rb*_LargeWavesTiling)/_value1);
                float4 _timer3 = _Time + _TimeEditor;
                float2 _largeWavesPanner = (i.uv0+(float3(0.0,(_LargeWavesSpeed/_division3))*(_timer3.r/100.0)));
                float2 node_4344 = (_largeWavesPanner+_flowMapStretch1);
                float2 _multiplier4 = (node_4344*_division3);
                float3 _LargeWavesTexNF = UnpackNormal(tex2D(_LargeWavesTexture,_multiplier4));
                float2 node_6670 = (_largeWavesPanner+_flowMapStretch2);
                float2 node_9787 = (node_6670*_division3);
                float3 _LargeWavesTexF = UnpackNormal(tex2D(_LargeWavesTexture,node_9787));
                float2 node_5083 = (_division3/node_4306);
                float2 node_6121 = (node_4344*node_5083);
                float3 _node_4423 = UnpackNormal(tex2D(_LargeWavesTexture,node_6121));
                float2 node_6938 = (node_6670*node_5083);
                float3 _node_4609 = UnpackNormal(tex2D(_LargeWavesTexture,node_6938));
                float2 node_4892 = (_division3/node_1864);
                float2 node_2573 = (node_4344*node_4892);
                float3 _node_4021 = UnpackNormal(tex2D(_LargeWavesTexture,node_2573));
                float2 node_988 = (node_6670*node_4892);
                float3 _node_590 = UnpackNormal(tex2D(_LargeWavesTexture,node_988));
                float3 _add1 = (lerp(float3(0,0,1),lerp(lerp(lerp(_SmallWavesTexNF.rgb,_SmallWavesTexF.rgb,node_5721),lerp(_node_8854.rgb,_node_9704.rgb,node_5721),node_7914),lerp(_node_8853.rgb,_node_1159.rgb,node_5721),node_7910),_SmallWaveRrefraction)+lerp(float3(0,0,1),lerp(lerp(lerp(_node_839.rgb,_MediumWavesTexF.rgb,_flowMapLerpControl),lerp(_node_8779.rgb,_node_1067.rgb,_flowMapLerpControl),node_7914),lerp(_node_4307.rgb,_node_5369.rgb,_flowMapLerpControl),node_7910),_MediumWaveRefraction)+lerp(float3(0,0,1),lerp(lerp(lerp(_LargeWavesTexNF.rgb,_LargeWavesTexF.rgb,_flowMapLerpControl),lerp(_node_4423.rgb,_node_4609.rgb,_flowMapLerpControl),node_7914),lerp(_node_4021.rgb,_node_590.rgb,_flowMapLerpControl),node_7910),_LargeWaveRefraction));
                float3 normalLocal = _add1;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float _multiplier1 = (pow(saturate((sceneZ-partZ)/_DepthTransparency),_ShoreFade)*saturate((sceneZ-partZ)/_ShoreTransparency));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + lerp(((_add1.rg*(_MediumWaveRefraction*0.02))*_multiplier1),float2(0,0),saturate(pow((distance(i.posWorld.rgb,_WorldSpaceCameraPos)/_RefractionDistance),_RefractionFalloff)));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);

                return sceneColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
