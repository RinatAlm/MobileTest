Shader "Unlit/Background__SHDR"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }


            // Table legs (sets up stuff for tables)
#define waveCount 5 // Recommended: 5
float3 waveColour[waveCount];
float waveOffset[waveCount];
float sineWave[waveCount * 5];

    fixed4 frag (v2f i) : SV_Target
    {
               // Big ol' table - All of the colours used, stored as RGB values
               // waveColour[0] = float3(0.807, 0.831, 0.854); // Pastel light orange
               // waveColour[1] = float3(0.678, 0.709, 0.741); // Pastel pinky orange
               // waveColour[2] = float3(0.423, 0.458, 0.490); // Pastel pink
               // waveColour[3] = float3(0.286, 0.313, 0.341); // Pastel purple
               // waveColour[4] = float3(0.203, 0.227, 0.250); // Pastel bluey purple
               waveColour[0] = float3(0.961, 0.682, 0.490); // Pastel light orange
               waveColour[1] = float3(0.925, 0.537, 0.486); // Pastel pinky orange
               waveColour[2] = float3(0.835, 0.412, 0.522); // Pastel pink
               waveColour[3] = float3(0.678, 0.329, 0.573); // Pastel purple
               waveColour[4] = float3(0.443, 0.290, 0.604); // Pastel bluey purple
               
               // Table 2: Electric Boogaloo - All of the heights of the waves
               waveOffset[0] = 0.8; // Recommended: 0.8
               waveOffset[1] = 0.64; // Recommended: 0.64
               waveOffset[2] = 0.48; // Recommended: 0.48
               waveOffset[3] = 0.32; // Recommended: 0.32
               waveOffset[4] = 0.16; // Recommended: 0.16
               
               // Not a table wowie - Variables that affect the shape of all waves
               float waveAmplitude = 0.05; // Recommended: 0.05
               float waveLength = -10.0; // Recommended: -10.0
               float waveSlowdown = 3.0; // Recommended: 3.0
               float transitionSmoothness = 0.002; // Recommended: 0.002

               // Normalise coordinates from 0 <> 1
               float2 uv = i.uv;// / iResolution.xy;
               
               // Sets the background colour (used at the top)
               float3 finalColour = float3(0.956, 0.831, 0.557);
               
               // Creates individual waves
               for (float i = 0.0; i < float(waveCount); i++) {
                   
                   // Table 3: It's back and smellier than ever - Groups of 5 are averaged and used to make each wave you see
                   // Group 1
                   sineWave[0] = waveAmplitude * 1.0 * sin (waveLength * 1.0 * uv.x + (_Time.y / waveSlowdown));
                   sineWave[1] = waveAmplitude * 2.1 * sin (waveLength * 1.21 * uv.x + (_Time.y / waveSlowdown));
                   sineWave[2] = waveAmplitude * 1.2 * sin (waveLength * 1.337 * uv.x + (_Time.y / waveSlowdown));
                   sineWave[3] = waveAmplitude * 1.3 * sin (waveLength * 1.69 * uv.x + (_Time.y / waveSlowdown));
                   sineWave[4] = waveAmplitude * 1.9 * sin (waveLength * 0.6 * uv.x + (_Time.y / waveSlowdown));
                   // Group 2
                   sineWave[5] = waveAmplitude * 2.2 * sin (waveLength * 1.2 * uv.x + (_Time.y / waveSlowdown / 2.0));
                   sineWave[6] = waveAmplitude * 1.2 * sin (waveLength * 3.2 * uv.x + (_Time.y / waveSlowdown / 2.0));
                   sineWave[7] = waveAmplitude * 2.1 * sin (waveLength * 0.75 * uv.x + (_Time.y / waveSlowdown / 2.0));
                   sineWave[8] = waveAmplitude * 1.23 * sin (waveLength * 1.43 * uv.x + (_Time.y / waveSlowdown / 2.0));
                   sineWave[9] = waveAmplitude * 0.22 * sin (waveLength * 0.56 * uv.x + (_Time.y / waveSlowdown / 2.0));
                   // Group 3
                   sineWave[10] = waveAmplitude * 1.3 * cos (waveLength * 1.2 * uv.x + (_Time.y / waveSlowdown / 1.5));
                   sineWave[11] = waveAmplitude * 1.7 * cos (waveLength * 2.5 * uv.x + (_Time.y / waveSlowdown / 1.5));
                   sineWave[12] = waveAmplitude * 1.1 * cos (waveLength * 1.1 * uv.x + (_Time.y / waveSlowdown / 1.5));
                   sineWave[13] = waveAmplitude * 1.43 * cos (waveLength * 1.6 * uv.x + (_Time.y / waveSlowdown / 1.5));
                   sineWave[14] = waveAmplitude * 2.3 * cos (waveLength * 0.2 * uv.x + (_Time.y / waveSlowdown / 1.5));
                   // Group 4
                   sineWave[15] = waveAmplitude * 1.6 * cos (waveLength * 2.54 * uv.x + (_Time.y / waveSlowdown / 3.0));
                   sineWave[16] = waveAmplitude * 1.31 * cos (waveLength * 1.02 * uv.x + (_Time.y / waveSlowdown / 3.0));
                   sineWave[17] = waveAmplitude * 2.02 * cos (waveLength * 0.92 * uv.x + (_Time.y / waveSlowdown / 3.0));
                   sineWave[18] = waveAmplitude * 2.65 * cos (waveLength * 0.43 * uv.x + (_Time.y / waveSlowdown / 3.0));
                   sineWave[19] = waveAmplitude * 1.92 * cos (waveLength * 0.2 * uv.x + (_Time.y / waveSlowdown / 3.0));
                   // Group 5 (- _Time.y reverses direction)
                   sineWave[20] = waveAmplitude * 0.8 * sin (waveLength * 1.52 * uv.x + (- _Time.y / waveSlowdown));
                   sineWave[21] = waveAmplitude * 1.4 * cos (waveLength * 0.97 * uv.x + (- _Time.y / waveSlowdown));
                   sineWave[22] = waveAmplitude * 1.2 * sin (waveLength * 1.23 * uv.x + (- _Time.y / waveSlowdown));
                   sineWave[23] = waveAmplitude * 0.7 * cos (waveLength * 0.83 * uv.x + (- _Time.y / waveSlowdown));
                   sineWave[24] = waveAmplitude * 1.0 * sin (waveLength * 1.00 * uv.x + (- _Time.y / waveSlowdown));
                   
                   // Start drawing some waves :O
                   float sum = 0.0;
                   for (float j = 0.0; j < float(waveCount); j++) {
                       sum += sineWave[int(int(j) + int(5) * int(i))]; // Adds together group of waves
                   }
                   float finalWave = (sum / float(waveCount)) + waveOffset[int(i)]; // Averages waves
                   if (uv.y < (finalWave)) // Checks for area below averaged wave
                   {
                       // Makes the transitions between colours less sharp
                       finalColour = lerp(finalColour, waveColour[int(i)], smoothstep(finalWave, finalWave - transitionSmoothness, uv.y));
                   }
                   
               }
               
               // Output to screen
               return float4(finalColour, 1.0);
            }
            ENDCG
        }
    }
}
