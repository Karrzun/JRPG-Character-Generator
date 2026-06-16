using System.Collections.Generic;
using SW = SeanWelton;

public static class CharacterFactory
{
    public static Character CreateRandomCharacter()
    {
        Sex sex = GetRandomBinarySex();

        CharacterStats stats = new CharacterStats();

        string familyName = NameGenerator.GetFamilyName();
        string givenName = NameGenerator.GetGivenName(sex);

        List<NarrativeTrait> traits = TraitGenerator.GetTraits(stats);

        NarrativeLocation origin = LocationGenerator.GetRandomOrigin();
        NarrativeOccupation occupation = OccupationGenerator.GetOccupationFromOrigin(origin, sex);

        Character character = new Character(familyName, givenName, sex, stats, traits, origin, occupation);

        return character;
    }

    private static Sex GetRandomBinarySex()
    {
        return SW.Random.Boolean() ? Sex.Female : Sex.Male;
    }
}