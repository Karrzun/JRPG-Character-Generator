using System.Text.RegularExpressions;

public static class CharacterDescriptionFormatter
{
    private const int MaxDescriptionLength = 650;

    public static string Format(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return string.Empty;

        string collapsed = CollapseWhitespace(description);
        string truncated = Truncate(collapsed, MaxDescriptionLength);

        return CutAfterLastFullSentence(truncated);
    }

    private static string CollapseWhitespace(string text)
    {
        return Regex.Replace(text.Trim(), @"\s+", " ");
    }

    private static string Truncate(string text, int maxLength)
    {
        if (text.Length <= maxLength)
            return text;

        return text.Substring(0, maxLength);
    }

    private static string CutAfterLastFullSentence(string text)
    {
        int lastPeriod = text.LastIndexOf('.');

        if (lastPeriod < 0)
            return text;

        return text.Substring(0, lastPeriod + 1);
    }
}