Shader "TSM2/BaseOutline"
{
    Properties 
    {
		[MaterialToggle(_TEX_ON)] _DetailTex ("Enable Detail texture", Float) = 1 	//1
		_MainTex ("Detail", 2D) = "white" {}        								//2
		_MainTexBlend("Detail Blend", Range(0.0, 2.0)) = 1
		_ToonShade ("Shade", 2D) = "white" {}										//3
		[MaterialToggle(_OUTLINE_TEX_ON)] _OutlineTexOn ("Enable Outline Detail", Float) = 0 	//4
		_OutlineTex ("Outline Detail", 2D) = "white" {}	
		[MaterialToggle(_COLOR_ON)] _TintColor ("Enable Color Tint", Float) = 0 	//4
		_Color ("Base Color", Color) = (0.5,0.5,0.5,1)									//5	
		[MaterialToggle(_VCOLOR_ON)] _VertexColor ("Enable Vertex Color", Float) = 0//6        
		_Brightness ("Brightness 1 = neutral", Float) = 1.0							//7	
		_OutlineColor ("Outline Color", Color) = (0.5,0.5,0.5,1.0)					//10
		_Outline ("Outline width", Float) = 0.01									//11
		_OutlineAnimationSpeed ("Outline Animation Speed", Range(0.0, 100.0)) = 0        	//12
		[MaterialToggle(_ASYM_ON)] _Asym ("Enable Asymmetry", Float) = 0        	//12
		_Asymmetry ("OutlineAsymmetry", Vector) = (0.0,0.25,0.5,0.0)     			//13
    }
 
    SubShader
    {
		// タグをTransparentに
		//Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }         
		Tags { "RenderType"="Opaque" }
		// ブレンド方法を加算に
		//Blend One One
		//Blend SrcAlpha OneMinusSrcAlpha
		//Blend DstColor SrcColor
		// ZTestを変更
		ZTest LEqual
		//Ztest GEqual
		LOD 250 
        Lighting Off
        Fog { Mode Off }
        
        UsePass "TSM2/Base/BASE"
        	
        Pass
        {
            Cull Front
            ZWrite On
            CGPROGRAM
			#include "UnityCG.cginc"
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma glsl_no_auto_normalization
            #pragma vertex vert
 			#pragma fragment frag
			#pragma multi_compile _ASYM_OFF _ASYM_ON _OUTLINE_TEX_ON
			
			sampler2D _MainTex;
			sampler2D _OutlineTex;
			half4 _MainTex_ST;

            struct appdata_t 
            {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				half2 uv : TEXCOORD0;
			};

			struct v2f 
			{
				float4 pos : SV_POSITION;
                    half2 uv : TEXCOORD0;
			};

            fixed _Outline;
            #if _ASYM_ON
            float4 _Asymmetry;
            #endif
            
            v2f vert (appdata_t v) 
            {
                v2f o;
			    o.pos = v.vertex;
                //    o.pos = mul ( UNITY_MATRIX_MVP, v.vertex);
o.uv = TRANSFORM_TEX ( v.uv, _MainTex);
			    #if _ASYM_ON
			    o.pos.xyz += (v.normal.xyz + _Asymmetry.xyz) *_Outline*0.01;
			    #else
			    o.pos.xyz += v.normal.xyz *_Outline*0.01;
			    #endif
			    o.pos = mul(UNITY_MATRIX_MVP, o.pos);

			    return o;
            }
            
            fixed4 _OutlineColor;
			float _OutlineAnimationSpeed;

            fixed4 frag(v2f i) :COLOR 
			{
				i.uv *= sin(3.1415 * _Time.x * _OutlineAnimationSpeed);
#ifdef _OUTLINE_TEX_ON
				fixed4 detail = tex2D ( _OutlineTex, i.uv);
#else
				fixed4 detail = _OutlineColor;
#endif
return detail;
			}
            ENDCG
        }
    }
    Fallback "Legacy Shaders/Diffuse"
}