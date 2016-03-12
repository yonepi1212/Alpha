Shader "TSM2/Base" 
{
    Properties 
    {
		[MaterialToggle(_TEX_ON)] _DetailTex ("Enable Detail texture", Float) = 0 	//1
		_MainTex ("Detail", 2D) = "white" {}        								//2
		_MainTexBlend("Detail Blend", Range(0.0, 2.0)) = 1
		_ToonShade ("Shade", 2D) = "white" {}  										//3
		[MaterialToggle(_COLOR_ON)] _TintColor ("Enable Color Tint", Float) = 0 	//4
		_Color ("Base Color", Color) = (0.5,0.5,0.5,1)									//5	
		[MaterialToggle(_VCOLOR_ON)] _VertexColor ("Enable Vertex Color", Float) = 0//6        
		_Brightness ("Brightness 1 = neutral", Float) = 1.0							//7	
    }
   
    Subshader 
    {
    	Tags { "RenderType"="Opaque" }
		LOD 250
    	ZWrite On
	   	Cull Back
		Lighting Off
		Fog { Mode Off }
		
        Pass 
        {
            Name "BASE"
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #include "UnityCG.cginc"
                #pragma glsl_no_auto_normalization
                #pragma multi_compile _TEX_OFF _TEX_ON
                #pragma multi_compile _COLOR_OFF _COLOR_ON
                #pragma multi_compile _VCOLOR_OFF _VCOLOR_ON
                
                #if _TEX_ON
                sampler2D _MainTex;
				half4 _MainTex_ST;
				#endif
				
                struct appdata_base0 
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float4 texcoord : TEXCOORD0;
					#if _VCOLOR_ON
					fixed4 color : COLOR;
					#endif
				};
				
                 struct v2f 
                 {
                    float4 pos : SV_POSITION;
                    #if _TEX_ON
                    half2 uv : TEXCOORD0;
                    #endif
                    half2 uvn : TEXCOORD1;
                    #if _VCOLOR_ON
					fixed4 color : COLOR;
					#endif
                 };
               
                v2f vert (appdata_base0 v)
                {
                    v2f o;
                    o.pos = mul ( UNITY_MATRIX_MVP, v.vertex);

                    float3 n = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                    n = n * float3(0.5,0.5,0.5) + float3(0.5,0.5,0.5);
                    o.uvn = n.xy;
                    #if _TEX_ON
                    o.uv = TRANSFORM_TEX ( v.texcoord, _MainTex );
                    #endif
                    #if _VCOLOR_ON
					o.color = v.color;
					#endif

                    return o;
                }

              	sampler2D _ToonShade;
                fixed _Brightness;
				float _MainTexBlend;

                #if _COLOR_ON
                fixed4 _Color;
                #endif
                
                fixed4 frag (v2f i) : COLOR
                {
					fixed4 toonShade = tex2D(_ToonShade, i.uvn);

					#if _VCOLOR_ON
					toonShade*=i.color;
					#endif
					
					// _MainTexBlend��1�𒴂����獕�����Ă���
					float texStrength = 1.0;
					if(_MainTexBlend > 1.0)
					{
						texStrength = texStrength - (_MainTexBlend - 1);
						_MainTexBlend = 1.0;
					}

					#if _TEX_ON
					fixed4 detail = tex2D ( _MainTex, i.uv);
					detail = detail * _MainTexBlend;
						#if _COLOR_ON
						// Detail�̃u�����h�ʂɔ���Ⴕ��_Color�����Z�����
						detail = detail + ( _Color * (1 - _MainTexBlend ));
						#else 
						#endif
					return  toonShade * detail * texStrength * _Brightness;
					#else

					return  toonShade * _Brightness;
					#endif
                }
            ENDCG
        }
    }
    Fallback "Legacy Shaders/Diffuse"
}