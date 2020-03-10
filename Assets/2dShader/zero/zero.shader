Shader "Unlit/zero"
{
	Properties
	{
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float timeDelta=_Time.y;
				float r=0.5+0.5*cos(timeDelta+i.uv.x+0);
				float g=0.5+0.5*cos(timeDelta+i.uv.y+2);
				float b=0.5+0.5*cos(timeDelta+i.uv.x+4);
				float4 finalCol = float4(r,g,b,1.0);
				return finalCol;
			}
			ENDCG
		}
	}
}
