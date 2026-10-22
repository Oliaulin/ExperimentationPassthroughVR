Shader "Custom/URPOcclusion"
{
    SubShader
    {
        Tags { "RenderPipeline"="UniversalPipeline" }

        Pass
        {
            Blend Zero One
            ZWrite On
            ColorMask 0
        }
    }
}