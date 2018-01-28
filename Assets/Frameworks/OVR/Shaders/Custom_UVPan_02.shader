Shader "Custom/Custom_UVPan_02" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
     	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
     	_AlphaMap ("Additional Alpha Map (Greyscale)", 2D) = "white" {}
		_ScrollXSpeed ("Pan U", Range(-10,10)) = 2	
		_ScrollYSpeed ("Pan V", Range(-10,10)) = 2
	}
	SubShader {
    	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		fixed _ScrollXSpeed;
		fixed _ScrollYSpeed;
		sampler2D _MainTex;
		sampler2D _AlphaMap;
		float4 _Color;

		struct Input {
			float2 uv_MainTex;
		};


		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput o) {

			fixed2 scrolledUV = 0;
			//IN.uv_MainTex;
			fixed xScrollValue = _ScrollXSpeed * _Time;
			fixed yScrollValue = _ScrollYSpeed * _Time;
			scrolledUV += fixed2 (xScrollValue, yScrollValue);

			half4 c = tex2D (_MainTex, scrolledUV);
			// Albedo comes from a texture tinted by color
			//fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Alpha = c.a * tex2D(_AlphaMap, IN.uv_MainTex).r;
		}
		ENDCG
	}
	FallBack "Transparent/VertexLit"
}
