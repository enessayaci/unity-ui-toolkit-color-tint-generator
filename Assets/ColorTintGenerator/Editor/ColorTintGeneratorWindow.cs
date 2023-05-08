using UnityEngine;
using UnityEditor;
using System.IO;

public class ColorTintGeneratorWindow : EditorWindow
{
    private string ussFilePath = "";
    private string primaryHex = "#efefff";
    private string secondaryHex = "#efefff";
    private string redHex = "#efefff";
    private string greenHex = "#efefff";
    private string blueHex = "#efefff";
    private string yellowHex = "#efefff";
    private string greyHex = "#efefff";

    [MenuItem("Tools/GenerateColorTint _colors.uss")]
    public static void ShowWindow()
    {
        GetWindow<ColorTintGeneratorWindow>("Generate _colors.uss");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Generate _colors.uss");

        ussFilePath = EditorGUILayout.TextField("USS File Path", ussFilePath);
        primaryHex = EditorGUILayout.TextField("Primary Hex", primaryHex);
        secondaryHex = EditorGUILayout.TextField("Secondary Hex", secondaryHex);
        redHex = EditorGUILayout.TextField("Red Hex", redHex);
        greenHex = EditorGUILayout.TextField("Green Hex", greenHex);
        blueHex = EditorGUILayout.TextField("Blue Hex", blueHex);
        yellowHex = EditorGUILayout.TextField("Yellow Hex", yellowHex);
        greyHex = EditorGUILayout.TextField("Grey Hex", greyHex);

        if (GUILayout.Button("Generate"))
        {
            GenerateUssFile();
        }
    }

    private void GenerateUssFile()
    {
        ColorTintGenerator colorGenerator = new ColorTintGenerator();
        float[] tintFactors = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1f };
        float[] shadeFactors = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1f };

        string ussContent = $":root {{\n" +
            $"--primary: {primaryHex};\n";

        GeneratePrimaryColors(ref ussContent, tintFactors, shadeFactors, colorGenerator);

        ussContent += $"\n--secondary: {secondaryHex};\n";

        GenerateSecondaryColors(ref ussContent, tintFactors, shadeFactors, colorGenerator);

        ussContent += $"\n--red: {redHex};\n";

        GenerateRedColors(ref ussContent, tintFactors, shadeFactors, colorGenerator);

        ussContent += $"\n--green: {greenHex};\n";

        GenerateGreenColors(ref ussContent, tintFactors, shadeFactors, colorGenerator);

        ussContent += $"\n--blue: {blueHex};\n";

        GenerateBlueColors(ref ussContent, tintFactors, shadeFactors, colorGenerator);

        ussContent += $"\n--yellow: {yellowHex};\n";

        GenerateYellowColors(ref ussContent, tintFactors, shadeFactors, colorGenerator);

        ussContent += $"\n--grey: {greyHex};\n";

        GenerateGreyColors(ref ussContent, tintFactors, shadeFactors, colorGenerator);

        ussContent += "}\n";

        File.WriteAllText(Path.Combine(Application.dataPath, ussFilePath, "colors.uss"), ussContent);
        Debug.Log($"colors.uss file generated at: {ussFilePath}");
    }

    private void GeneratePrimaryColors(ref string result, float[] tintFactors, float[] shadeFactors, ColorTintGenerator colorGenerator)
    {
        Color[] variations = colorGenerator.GenerateTintsAndShades(primaryHex, tintFactors, shadeFactors);

        for (int i = 0; i < tintFactors.Length; i++)
        {
            string tintName = $"--primary-light-{(i + 1) * 10}";
            string tintValue = $"#{ColorUtility.ToHtmlStringRGB(variations[i])};";
            result += $"{tintName}: {tintValue}\n";
        }

        for (int i = 0; i < shadeFactors.Length; i++)
        {
            string shadeName = $"--primary-dark-{(i + 1) * 10}";
            string shadeValue = $"#{ColorUtility.ToHtmlStringRGB(variations[variations.Length - i - 1])};";
            result += $"{shadeName}: {shadeValue}\n";
        }

    }

    private void GenerateSecondaryColors(ref string result, float[] tintFactors, float[] shadeFactors, ColorTintGenerator colorGenerator)
    {
        Color[] variations = colorGenerator.GenerateTintsAndShades(secondaryHex, tintFactors, shadeFactors);

        for (int i = 0; i < tintFactors.Length; i++)
        {
            string tintName = $"--secondary-light-{(i + 1) * 10}";
            string tintValue = $"#{ColorUtility.ToHtmlStringRGB(variations[i])};";
            result += $"{tintName}: {tintValue}\n";
        }

        for (int i = 0; i < shadeFactors.Length; i++)
        {
            string shadeName = $"--secondary-dark-{(i + 1) * 10}";
            string shadeValue = $"#{ColorUtility.ToHtmlStringRGB(variations[variations.Length - i - 1])};";
            result += $"{shadeName}: {shadeValue}\n";
        }

    }

    private void GenerateRedColors(ref string result, float[] tintFactors, float[] shadeFactors, ColorTintGenerator colorGenerator)
    {
        Color[] variations = colorGenerator.GenerateTintsAndShades(redHex, tintFactors, shadeFactors);

        for (int i = 0; i < tintFactors.Length; i++)
        {
            string tintName = $"--red-light-{(i + 1) * 10}";
            string tintValue = $"#{ColorUtility.ToHtmlStringRGB(variations[i])};";
            result += $"{tintName}: {tintValue}\n";
        }

        for (int i = 0; i < shadeFactors.Length; i++)
        {
            string shadeName = $"--red-dark-{(i + 1) * 10}";
            string shadeValue = $"#{ColorUtility.ToHtmlStringRGB(variations[variations.Length - i - 1])};";
            result += $"{shadeName}: {shadeValue}\n";
        }

    }

    private void GenerateGreenColors(ref string result, float[] tintFactors, float[] shadeFactors, ColorTintGenerator colorGenerator)
    {
        Color[] variations = colorGenerator.GenerateTintsAndShades(greenHex, tintFactors, shadeFactors);

        for (int i = 0; i < tintFactors.Length; i++)
        {
            string tintName = $"--green-light-{(i + 1) * 10}";
            string tintValue = $"#{ColorUtility.ToHtmlStringRGB(variations[i])};";
            result += $"{tintName}: {tintValue}\n";
        }

        for (int i = 0; i < shadeFactors.Length; i++)
        {
            string shadeName = $"--green-dark-{(i + 1) * 10}";
            string shadeValue = $"#{ColorUtility.ToHtmlStringRGB(variations[variations.Length - i - 1])};";
            result += $"{shadeName}: {shadeValue}\n";
        }

    }

    private void GenerateBlueColors(ref string result, float[] tintFactors, float[] shadeFactors, ColorTintGenerator colorGenerator)
    {
        Color[] variations = colorGenerator.GenerateTintsAndShades(blueHex, tintFactors, shadeFactors);

        for (int i = 0; i < tintFactors.Length; i++)
        {
            string tintName = $"--blue-light-{(i + 1) * 10}";
            string tintValue = $"#{ColorUtility.ToHtmlStringRGB(variations[i])};";
            result += $"{tintName}: {tintValue}\n";
        }

        for (int i = 0; i < shadeFactors.Length; i++)
        {
            string shadeName = $"--blue-dark-{(i + 1) * 10}";
            string shadeValue = $"#{ColorUtility.ToHtmlStringRGB(variations[variations.Length - i - 1])};";
            result += $"{shadeName}: {shadeValue}\n";
        }

    }

    private void GenerateYellowColors(ref string result, float[] tintFactors, float[] shadeFactors, ColorTintGenerator colorGenerator)
    {
        Color[] variations = colorGenerator.GenerateTintsAndShades(yellowHex, tintFactors, shadeFactors);

        for (int i = 0; i < tintFactors.Length; i++)
        {
            string tintName = $"--yellow-light-{(i + 1) * 10}";
            string tintValue = $"#{ColorUtility.ToHtmlStringRGB(variations[i])};";
            result += $"{tintName}: {tintValue}\n";
        }

        for (int i = 0; i < shadeFactors.Length; i++)
        {
            string shadeName = $"--yellow-dark-{(i + 1) * 10}";
            string shadeValue = $"#{ColorUtility.ToHtmlStringRGB(variations[variations.Length - i - 1])};";
            result += $"{shadeName}: {shadeValue}\n";
        }

    }

    private void GenerateGreyColors(ref string result, float[] tintFactors, float[] shadeFactors, ColorTintGenerator colorGenerator)
    {
        Color[] variations = colorGenerator.GenerateTintsAndShades(greyHex, tintFactors, shadeFactors);

        for (int i = 0; i < tintFactors.Length; i++)
        {
            string tintName = $"--grey-light-{(i + 1) * 10}";
            string tintValue = $"#{ColorUtility.ToHtmlStringRGB(variations[i])};";
            result += $"{tintName}: {tintValue}\n";
        }

        for (int i = 0; i < shadeFactors.Length; i++)
        {
            string shadeName = $"--grey-dark-{(i + 1) * 10}";
            string shadeValue = $"#{ColorUtility.ToHtmlStringRGB(variations[variations.Length - i - 1])};";
            result += $"{shadeName}: {shadeValue}\n";
        }

    }
}