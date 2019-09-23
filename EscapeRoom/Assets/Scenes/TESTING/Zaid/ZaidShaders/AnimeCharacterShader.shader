
Shader "Zaid/Anime/ModularAnimeShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_BumpMap("Bump", 2D) = "bump" {}
		_Ramp("Ramp", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_OutlineCol("Outline Color", Color) = (1,1,1,1)
		_Ambient("Ambient Color", Color) = (1,1,1,1)
		_RimColor("RimColor", Color) = (1,1,1,1)
		_SpecularPower("SpecularPower",Range(0.0,4)) = 2.0
		_Gloss("SpecularGloss",Range(0.0,8)) = 2.0
		_RimPower("RimPower", Range(0.05,5)) = 5
		_BumpIntensity("BumpIntensity",Range(0.0,4)) = 2.0
		_AmbientStrength("Ambient Strength", Range(0.00,1.0)) = 0.00
		_OutlineVal("Outline",Range(0.0,1)) = 1.0
	}

		Subshader
		{

		Pass
		
{			
			Cull Front
		
		Name "BASE"

		CGPROGRAM

		#pragma vertex VertexProgram
		#pragma fragment frag
		#pragma fragmentoption ARB_precision_hint_fastest
		#include "UnityCG.cginc"


		struct v2f
		{
		float4 pos : SV_POSITION;

		};

		float _OutlineVal;
		float adaptedOutline;
		float dist;
		float2 offset;
		float4 VertexProgram(
			float4 position : POSITION,
			float3 normal : NORMAL) : SV_POSITION{
			float multiplier = unity_OrthoParams.x * 0.1;

			if (multiplier < 1.25) {
				multiplier = 1.25;
			}
			float4 clipPosition = UnityObjectToClipPos(position);
			float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normal));
			offset = normalize(clipNormal.xy) / _ScreenParams.xy * multiplier* clipPosition.w * 1.5;
			clipPosition.xy += offset;
		return clipPosition;

		}


		fixed4 _OutlineCol;
		
		fixed4 frag(v2f i) : SV_Target{
		return _OutlineCol;
		}
		ENDCG

}

		Tags{"RenderType" = "Opaque" }

			Cull Back
			Lighting On



		CGPROGRAM
		#pragma surface surf Ramp 

		sampler2D _Ramp;
		float4 _Color;
		float4 _RimColor;
		float4 _Ambient;
		float _AmbientStrength;
		float _SpecularPower;
		float _Gloss;
		float _BumpIntensity;
		float _RimPower;
		float _OutlineVal;
		sampler2D _MainTex;
		sampler2D _BumpMap;




		half4 LightingRamp(SurfaceOutput s, half3 lightDir, half3 viewDir,half atten) {
			_Ambient = _Ambient * _AmbientStrength;
			half3 h = normalize(lightDir + viewDir);
			half NdotL = dot(s.Normal, lightDir);
			half diff = NdotL * 0.5 + 0.5;
			half diffShine = max(1, dot(s.Normal, lightDir*_BumpIntensity));
			float nh = max(0, dot(s.Normal, h));
			float spec = pow(nh, 48.0*_Gloss)*_SpecularPower;
			half4 ramp = tex2D(_Ramp, float2(diff, 1 * diff)).rgba;
			half4 c;
			c.rgb = (s.Albedo * _LightColor0.rgb * diff + (_LightColor0.rgb+_Ambient) * spec) * atten*ramp;
			c.a = 0;
			return c;
		}






		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float4 screenPos;
			float3 viewDir;
			
		};
	
		void surf(Input IN, inout SurfaceOutput o) {

			fixed4 finalColor = tex2D(_MainTex, IN.uv_MainTex).rgba*_Color;
			o.Gloss = 100;
			half rim = 1 - saturate(dot(IN.viewDir,  o.Normal));
			o.Emission =  (_RimColor.rgb )*pow(rim / 8, 1.5)*_RimPower;
			o.Albedo = finalColor.rgba;
			o.Alpha = 255;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

		}
		ENDCG
		
	}
		Fallback "Standard"
}
