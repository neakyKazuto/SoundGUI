namespace SoundGUI.Extensions;

public static class StringExtensions
{
    public static int LineCount(this string LineC)
    {
        return LineC.Split('\n').Length;
    }
}