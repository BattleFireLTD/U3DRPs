Shader "RP1/Standard"{
    Properties{
    }
    SubShader{
        Pass{
        Tags { "RenderType"="Opaque" "LightMode"="RP1Shader" }
            HLSLPROGRAM
			#pragma vertex RP1Vertex
			#pragma fragment RP1Fragment
            float4x4 unity_ObjectToWorld;
            float4x4 unity_MatrixVP;
            struct Attributes {
	            float3 position : POSITION;
            };
            struct Varyings {
                float4 position : SV_POSITION;
            };
            Varyings RP1Vertex(Attributes input) {
                Varyings output;
                float4 world_pos = mul(unity_ObjectToWorld,float4(input.position,1.0));
                output.position = mul(unity_MatrixVP,world_pos);
                return output;
            }
            float4 RP1Fragment(Varyings input) :SV_TARGET {
                return float4(1.0,1.0,1.0,1.0);
            }
			ENDHLSL
        }
    }
    FallBack "Diffuse"
}
