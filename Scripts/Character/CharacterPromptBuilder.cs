using System.Linq;
using System.Text;

public static class CharacterPromptBuilder
{
    public static string BuildPrompt(Character character)
    {
        if (character == null)
            return string.Empty;

        StringBuilder sb = new StringBuilder();

        sb.Append($"{character.FullName} ");
        sb.Append($"({character.Sex}), ");
        sb.Append($"{character.Occupation.Name} ");
        sb.Append($"from {character.Origin.Name}: ");

        sb.Append(BuildTraitList(character));

        return sb.ToString();
    }

    private static string BuildTraitList(Character character)
    {
        if (character.Traits == null || character.Traits.Count == 0)
            return "No notable traits.";

        string traitList = string.Join(", ", character.Traits.Select(trait => trait.Name));
        return $"{traitList}.";
    }
}