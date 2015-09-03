Shader "Custom/FlatColor" {
	Properties {
		_Color ("Color", Color) = (1.0,1.0,1.0,1.0)
	}
	SubShader {
		Pass {
			CGPROGRAM

				// pragmas
				#pragma vertex vert 
				#pragma fragment frag

				// user defined variables
				uniform float4 _Color;

				//base input structures
				struct vertexInput{
					float4 vertex : POSITION;
				};

				struct vertexOutput {
					float4 pos : SV_POSITION;
				};

				//vertex funtion
				vertexOutput vert(vertexInput v) {
					vertexOutput o;
					o.pos = mul (UNITY_MATRIX_MVP, v.vertex);

					return o;
				} 

				//fraGgment function
				float4 frag(vertexOutput i) : COLOR {
					return _Color;
				}

			ENDCG
		}

	}
	//FallBack "Diffuse"
}
