Shader "User/AlphaErosion" {
	Properties {
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[ASEBegin] _Color0 ("Color 0", Vector) = (0.5754717,0.5754717,0.5754717,1)
		_EmmisiveAmount ("EmmisiveAmount", Float) = 0
		_LightAmount ("LightAmount", Float) = 0
		_Scale ("Scale", Float) = 0.5
		_Erosion ("Erosion", 2D) = "white" {}
		_VertexOffsetAmount ("VertexOffsetAmount", Float) = 0
		_Direction ("Direction", Vector) = (0.49,0,0,0)
		[ASEEnd] _AlphaClip ("AlphaClip", Float) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Hidden/InternalErrorShader"
	//CustomEditor "UnityEditor.ShaderGraph.PBRMasterGUI"
}