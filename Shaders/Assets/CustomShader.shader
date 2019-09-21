Shader "Custom/CustomShader" {
	Properties {
		//get from interface
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SecondTex("Albedo (RGB)", 2D) = "white" {}
		_ThirdTex("Albedo (RGB)", 2D) = "white" {}
		_Fade ("Fade color", Color) = (1,1,1,1)
		_Range("Fade Range",float)=0.5
		_RangeExtra("Fade Extra Range",float)=0.1
		//get from script	
		_TextureSelection("Texture Selection",Int)=0
		_Mouse ("Mouse hit",Vector)=(0,0,0,0)
		_Flow ("flow direction",Vector)=(0,0,0,0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" 
				//"IgnoreProjector"="True"
				"Queue"="Transparent"}
		Cull Back
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard alpha:fade 
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _SecondTex;
		sampler2D _ThirdTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		int _TextureSelection;
		fixed4 _Fade;
		float _Range;
		float _RangeExtra;
		float3 _Mouse;
		float3 _Flow;

		UNITY_INSTANCING_BUFFER_START(Props)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c ;
			//mouse clicks
			if (_TextureSelection == 0) {
				c = tex2D(_MainTex, IN.uv_MainTex + _Time * _Flow);
			}
			else if (_TextureSelection == 1)
			{
				c = tex2D(_SecondTex, IN.uv_MainTex + _Time * _Flow);
			}
			else
			{
				c = tex2D(_ThirdTex, IN.uv_MainTex + _Time * _Flow);
			}
			//calculations
			float d= distance(_Mouse,IN.worldPos);
			float fadeRate=((d-_Range)/(_RangeExtra));
			//display
			if(d<_Range){
				o.Albedo = c.rgb;
				o.Alpha=0;
			}
			else if(d<_Range+_RangeExtra)
			{
				o.Albedo = c.rgb+_Fade*fadeRate;
				o.Alpha=fadeRate;
			}
			else
			{
			o.Albedo = c.rgb;
			o.Alpha=1;
			}	
			o.Metallic = 0.5;
			o.Smoothness = 0.5;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
