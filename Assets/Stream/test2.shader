Shader "Custom/test2"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpTex("Normal Map", 2D) = "bump" {}
	}
		SubShader
		{
			Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }


			zwrite on
			ColorMask 0
			CGPROGRAM

			#pragma surface surf _NoLit nolight keepalpha noambient noforwardadd nolightmap novertexlights noshadow        

			struct Input
			{
				float2 color:COLOR;
			};

			void surf(Input IN, inout SurfaceOutput o)
			{
			}
			float4 Lighting_NoLit(SurfaceOutput s, float3 lightDir, float atten)
			{
				return 0.0f;
			}
			ENDCG


			zwrite off
			CGPROGRAM

			#pragma surface surf Lambert alpha:blend

			sampler2D _MainTex;
			sampler2D _BumpTex;

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_BumpTex;
			};

			fixed4 _Color;

			void surf(Input IN, inout SurfaceOutput o)
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;

				float2 distuv = float2(IN.uv_BumpTex.x, IN.uv_BumpTex.y + _Time.x * 8);
				float3 n = UnpackNormal(tex2D(_BumpTex, distuv));
				o.Normal = n;

				o.Alpha = 1;
			}
			ENDCG
			
		}
}
