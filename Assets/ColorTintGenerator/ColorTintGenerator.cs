using UnityEngine;

public class ColorTintGenerator
{
    public Color[] GenerateTintsAndShades(string hexColor, float[] tintFactors, float[] shadeFactors)
    {
        Color baseColor = HexToColor(hexColor);
        int numTints = tintFactors.Length;
        int numShades = shadeFactors.Length;
        int numVariations = numTints + numShades + 1; // base color + tints + shades
        Color[] variations = new Color[numVariations];

        // Generate tints
        for (int i = 0; i < numTints; i++)
        {
            float tintFactor = tintFactors[i];
            Color tint = new Color(
                Mathf.Lerp(baseColor.r, 1f, tintFactor),
                Mathf.Lerp(baseColor.g, 1f, tintFactor),
                Mathf.Lerp(baseColor.b, 1f, tintFactor)
            );
            variations[i] = tint;
        }

        // Add base color
        variations[numTints] = baseColor;

        // Generate shades
        for (int i = 0; i < numShades; i++)
        {
            float shadeFactor = shadeFactors[i];
            Color shade = new Color(
                Mathf.Lerp(baseColor.r, 0f, shadeFactor),
                Mathf.Lerp(baseColor.g, 0f, shadeFactor),
                Mathf.Lerp(baseColor.b, 0f, shadeFactor)
            );
            variations[numVariations - i - 1] = shade;
        }

        return variations;
    }

    private Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
}