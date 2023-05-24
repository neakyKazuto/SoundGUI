namespace SoundGUI.Extensions;

public static class StringExtensions
{
    public static int LineCount(this string LineC)
    {
        return string.IsNullOrEmpty(LineC) ? 0 :  LineC.Split('\n').Length;
    }
}