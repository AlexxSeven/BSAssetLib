// Made with Amplify Shader Editor v1.9.2
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "AlexxSeven/Tests/AssetLib Example"
{
	Properties
	{
		[Enum(Saber L,0,Saber R,1,Light 0,2,Light 1,3,Boost 0,4,Boost 1,5,Walls,6)]_SchemeID("Scheme ID", Float) = 0
		[Toggle][ToggleUI]_LinearToggle("LinearToggle", Float) = 1
		_Glow("Glow", Range( 0 , 1)) = 0

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Opaque" }
	LOD 100

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend Off
		AlphaToMask Off
		Cull Back
		ColorMask RGBA
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		
		
		
		Pass
		{
			Name "Unlit"

			CGPROGRAM

			

			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			//only defining to not throw compilation error over Unity 5.5
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			

			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 worldPos : TEXCOORD0;
				#endif
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			uniform float _SchemeID;
			uniform float _LinearToggle;
			uniform float4 _ColSaberL;
			uniform float4 _ColSaberR;
			uniform float4 _ColLight0;
			uniform float4 _ColLight1;
			uniform float4 _ColBoost0;
			uniform float4 _ColBoost1;
			uniform float4 _ColWall;
			uniform float _Glow;
			float4 colorEnum( float ID, float Linear, float4 Example1, float4 Example2, float4 Example3, float4 Example4, float4 Example5, float4 Example6, float4 Example7 )
			{
				float4 col;
				if( ID == 0) {
					col = Example1;
				} else if ( ID == 1) {
					col = Example2;
				} else if ( ID == 2) {
					col = Example3;
				} else if ( ID == 3) {
					col = Example4;
				} else if ( ID == 4) {
					col = Example5;
				} else if ( ID == 5) {
					col = Example6;
				} else {
					col = Example7;
				}
				if(Linear == 1) {
					col.rgb = GammaToLinearSpace(col.rgb);
				}
				return col;
			}
			

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_OUTPUT(v2f, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				
				float3 vertexValue = float3(0, 0, 0);
				#if ASE_ABSOLUTE_VERTEX_POS
				vertexValue = v.vertex.xyz;
				#endif
				vertexValue = vertexValue;
				#if ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				o.vertex = UnityObjectToClipPos(v.vertex);

				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#endif
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				fixed4 finalColor;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 WorldPosition = i.worldPos;
				#endif
				float ID6 = _SchemeID;
				float Linear6 = _LinearToggle;
				float4 Example16 = _ColSaberL;
				float4 Example26 = _ColSaberR;
				float4 Example36 = _ColLight0;
				float4 Example46 = _ColLight1;
				float4 Example56 = _ColBoost0;
				float4 Example66 = _ColBoost1;
				float4 Example76 = _ColWall;
				float4 localcolorEnum6 = colorEnum( ID6 , Linear6 , Example16 , Example26 , Example36 , Example46 , Example56 , Example66 , Example76 );
				float4 appendResult17 = (float4((localcolorEnum6).xyz , ( (localcolorEnum6).w * _Glow )));
				
				
				finalColor = appendResult17;
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	Fallback Off
}
/*ASEBEGIN
Version=19200
Node;AmplifyShaderEditor.RangedFloatNode;14;-608.932,-271.6091;Inherit;False;Property;_LinearToggle;LinearToggle;1;2;[Toggle];[ToggleUI];Create;False;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;112.7612,195.3646;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;19;-165.2388,394.3646;Inherit;False;Property;_Glow;Glow;2;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;16;-112.2251,180.3646;Inherit;False;False;False;False;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;15;-116.4442,93.14545;Inherit;False;True;True;True;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;5;-578.1997,-338.4002;Inherit;False;Property;_SchemeID;Scheme ID;0;1;[Enum];Create;False;0;7;Saber L;0;Saber R;1;Light 0;2;Light 1;3;Boost 0;4;Boost 1;5;Walls;6;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;7;-640.5,-39;Inherit;False;Global;_ColSaberR;_ColSaberR;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;10;-635.5,456;Inherit;False;Global;_ColBoost0;_ColBoost0;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;12;-631.5,618;Inherit;False;Global;_ColBoost1;_ColBoost1;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;13;-628.5,780;Inherit;False;Global;_ColWall;_ColWall;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;9;-636.5,293;Inherit;False;Global;_ColLight1;_ColLight1;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;8;-636.5,127;Inherit;False;Global;_ColLight0;_ColLight0;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;1;-638.5,-205;Inherit;False;Global;_ColSaberL;_ColSaberL;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CustomExpressionNode;6;-364.3632,110.9452;Inherit;False;float4 col@$$if( ID == 0) {$	col = Example1@$} else if ( ID == 1) {$	col = Example2@$} else if ( ID == 2) {$	col = Example3@$} else if ( ID == 3) {$	col = Example4@$} else if ( ID == 4) {$	col = Example5@$} else if ( ID == 5) {$	col = Example6@$} else {$	col = Example7@$}$$if(Linear == 1) {$	col.rgb = GammaToLinearSpace(col.rgb)@$}$$return col@;4;Create;9;True;ID;FLOAT;0;In;;Inherit;False;True;Linear;FLOAT;0;In;;Inherit;False;True;Example1;FLOAT4;0,0,0,0;In;;Inherit;False;True;Example2;FLOAT4;0,0,0,0;In;;Inherit;False;True;Example3;FLOAT4;0,0,0,0;In;;Inherit;False;True;Example4;FLOAT4;0,0,0,0;In;;Inherit;False;True;Example5;FLOAT4;0,0,0,0;In;;Inherit;False;True;Example6;FLOAT4;0,0,0,0;In;;Inherit;False;True;Example7;FLOAT4;0,0,0,0;In;;Inherit;False;colorEnum;False;False;0;;False;9;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT4;0,0,0,0;False;3;FLOAT4;0,0,0,0;False;4;FLOAT4;0,0,0,0;False;5;FLOAT4;0,0,0,0;False;6;FLOAT4;0,0,0,0;False;7;FLOAT4;0,0,0,0;False;8;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;17;241.3705,103.93;Inherit;False;COLOR;4;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;32;394.4039,66.41422;Float;False;True;-1;2;ASEMaterialInspector;100;5;AlexxSeven/Tests/AssetLib Example;0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;False;True;0;1;False;;0;False;;0;1;False;;0;False;;True;0;False;;0;False;;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;RenderType=Opaque=RenderType;True;2;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;0;1;True;False;;False;0
WireConnection;18;0;16;0
WireConnection;18;1;19;0
WireConnection;16;0;6;0
WireConnection;15;0;6;0
WireConnection;6;0;5;0
WireConnection;6;1;14;0
WireConnection;6;2;1;0
WireConnection;6;3;7;0
WireConnection;6;4;8;0
WireConnection;6;5;9;0
WireConnection;6;6;10;0
WireConnection;6;7;12;0
WireConnection;6;8;13;0
WireConnection;17;0;15;0
WireConnection;17;3;18;0
WireConnection;32;0;17;0
ASEEND*/
//CHKSM=CDAF98EAD7E22FB56306C4081E20D93175F3F18F