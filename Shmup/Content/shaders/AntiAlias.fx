float xSize;
float ySize;
float xDraw;
float yDraw;
float4 filterColor;

texture Texture;
sampler TextureSampler = sampler_state
{
    Texture = <Texture>;
};


struct VertexShadeOutput{
    float4 Position: SV_POSITION;
    float4 Color: COLOR0;
    float2 TextureCoordinate: TEXCOORD0;
};

float4 PixelShaderFunction(VertexShadeOutput input):COLOR{
    float4 texColor = tex2D(TextureSampler, input.TextureCoordinate);

    float vertPixSize = 1.0f/ySize;
    float horiPixSize = 1.0f/xSize;

    float4 color;
    if(xDraw/xSize < .6f || yDraw/ySize < .6f){
        if(xDraw/xSize < .4f || yDraw/ySize < .4f){
            vertPixSize = 2.0f/ySize;
            horiPixSize = 2.0f/xSize;
        }
        float4 aboveColor = tex2D(TextureSampler, (input.TextureCoordinate) + float2(0, -vertPixSize));
        float4 belowColor = tex2D(TextureSampler, (input.TextureCoordinate) + float2(0, vertPixSize));
        float4 leftColor = tex2D(TextureSampler, (input.TextureCoordinate) + float2(-horiPixSize,0 ));
        float4 rightColor = tex2D(TextureSampler, (input.TextureCoordinate) + float2(horiPixSize,0 ));

        color = float4((texColor.r + aboveColor.r + belowColor.r + leftColor.r + rightColor.r)/5,
		 (texColor.g + aboveColor.g + belowColor.g + leftColor.g + rightColor.g)/5, 
		 (texColor.b + aboveColor.b + belowColor.b + leftColor.b + rightColor.b)/5, 
		 (texColor.a + aboveColor.a + belowColor.a + leftColor.a + rightColor.a)/5);

    }else{
        color = float4(texColor.r, texColor.g, texColor.b, texColor.a);
    }

    return color * filterColor;
}

technique Technique1{
    pass Pass1{
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}