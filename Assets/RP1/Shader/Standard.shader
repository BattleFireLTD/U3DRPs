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
            float4x4 unity_WorldToObject;
            float4x4 unity_MatrixVP;
            float4 MainLightPosition;
            float4 MainLightColor;
            struct Attributes {
	            float3 position : POSITION;
                float3 normal : NORMAL;
            };
            struct Varyings {
                float4 position : SV_POSITION;
                float3 normal : NORMAL;
            };
            Varyings RP1Vertex(Attributes input) {
                Varyings output;
                float4 world_pos = mul(unity_ObjectToWorld,float4(input.position,1.0));
                output.position = mul(unity_MatrixVP,world_pos);
                float3 normal=mul(float4(input.normal,0.0),unity_WorldToObject).xyz;
                output.normal=normalize(normal);
                return output;
            }
            float4 RP1Fragment(Varyings input) :SV_TARGET {
                float3 L=normalize(MainLightPosition.xyz);
                float3 normal=normalize(input.normal);
                float attenuation=max(dot(L,normal),0.0);
                float3 color=attenuation*MainLightColor.rgb;
                return float4(color,1.0);
            }
			ENDHLSL
        }
    }
    FallBack "Diffuse"
}
