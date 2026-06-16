using SeanWelton.Stats;
using System.Collections.Generic;
using System.Linq;


public static class TraitGenerator
{
    private const int MAX_TRAIT_COUNT = 4;

    public static readonly List<NarrativeTrait> traits = new List<NarrativeTrait>
    {
        // Single stat traits
        // Each of these has an empiric chance of ~ 8.1 % (due to 3 out of 5 character selection)
        new NarrativeTrait("Unbreakable",   80,     c => c.CON == 20),
        new NarrativeTrait("Oni-Blooded",   80,     c => c.STR == 20),
        new NarrativeTrait("Skilled",       80,     c => c.DEX == 20),
        new NarrativeTrait("Shadowstep",    80,     c => c.AGI == 20),
        new NarrativeTrait("Mastermind",    80,     c => c.INT == 20),
        new NarrativeTrait("Sagacious",     80,     c => c.WIS == 20),
        new NarrativeTrait("Iron Will",     80,     c => c.WIL == 20),
        new NarrativeTrait("Eloquent",      80,     c => c.CHA == 20),
        
        // ~ 52.1 %
        new NarrativeTrait("Enduring",      10,     c => c.CON > 13),
        new NarrativeTrait("Strong",        10,     c => c.STR > 13),
        new NarrativeTrait("Handy",         10,     c => c.DEX > 13),
        new NarrativeTrait("Swift",         10,     c => c.AGI > 13),
        new NarrativeTrait("Intelligent",   10,     c => c.INT > 13),
        new NarrativeTrait("Spiritual",     10,     c => c.WIS > 13),
        new NarrativeTrait("Disciplined",   10,     c => c.WIL > 13),
        new NarrativeTrait("Charismatic",   10,     c => c.CHA > 13),

        // ~ 8.7 %
        new NarrativeTrait("Fragile",       75,     c => c.CON < 7),
        new NarrativeTrait("Weak",          75,     c => c.STR < 7),
        new NarrativeTrait("Clumsy",        75,     c => c.DEX < 7),
        new NarrativeTrait("Sluggish",      75,     c => c.AGI < 7),
        new NarrativeTrait("Fogminded",     75,     c => c.INT < 7),
        new NarrativeTrait("Naive",         75,     c => c.WIS < 7),
        new NarrativeTrait("Unmoored",      75,     c => c.WIL < 7),
        new NarrativeTrait("Dull",          75,     c => c.CHA < 7),


        // Double stat traits
        new NarrativeTrait("Iron Scholar",  94,     c => c.CON == 20 && c.INT > 15),    // ~ 02.9
        new NarrativeTrait("Brute",         95,     c => c.STR == 20 && c.INT < 11),    // ~ 02.6
        new NarrativeTrait("Steady Hand",   94,     c => c.DEX == 20 && c.WIL > 15),    // ~ 02.9
        new NarrativeTrait("Living Blade",  94,     c => c.AGI == 20 && c.DEX > 15),    // ~ 02.9
        new NarrativeTrait("Furious",       95,     c => c.WIL == 20 && c.CON < 11),    // ~ 02.7
        new NarrativeTrait("Foolish",       95,     c => c.CHA == 20 && c.WIS < 11),    // ~ 02.7
        
        new NarrativeTrait("Resilient",     49,     c => c.CON > 14 && c.STR > 12),     // ~ 25.6
        new NarrativeTrait("Athletic",      52,     c => c.CON > 11 && c.STR > 15),     // ~ 24.0
        new NarrativeTrait("Acrobatic",     52,     c => c.CON > 11 && c.AGI > 15),     // ~ 24.1
        new NarrativeTrait("Carefree",      73,     c => c.CON > 13 && c.INT < 10),     // ~ 13.4
        new NarrativeTrait("Tough",         33,     c => c.CON > 14 && c.WIS > 9),      // ~ 33.6
        new NarrativeTrait("Feral",         70,     c => c.CON > 12 && c.WIS < 10),     // ~ 14.9
        new NarrativeTrait("Tenacious",     49,     c => c.CON > 14 && c.WIL > 12),     // ~ 25.5
        
        new NarrativeTrait("Soft",          84,     c => c.CON < 11 && c.STR < 11),     // ~ 07.8
        new NarrativeTrait("Frail Scholar", 91,     c => c.CON < 8 && c.INT > 16),      // ~ 04.7
        new NarrativeTrait("Cautious",      70,     c => c.CON < 10 && c.WIS > 12),     // ~ 14.8
        new NarrativeTrait("Reckless",      82,     c => c.CON < 10 && c.WIS < 13),     // ~ 09.0

        new NarrativeTrait("Battle-Tested", 80,     c => c.STR > 17 && c.DEX > 14),     // ~ 10.2
        new NarrativeTrait("Slow-Moving",   85,     c => c.STR > 15 && c.AGI < 9),      // ~ 07.8
        new NarrativeTrait("Bloodthirsty",  87,     c => c.STR > 16 && c.WIS < 9),      // ~ 06.4
        new NarrativeTrait("Tactician",     80,     c => c.STR > 17 && c.WIS > 14),     // ~ 10.1
        new NarrativeTrait("Focused",       52,     c => c.STR > 11 && c.WIL > 15),     // ~ 24.1
        new NarrativeTrait("Impulsive",     74,     c => c.STR > 13 && c.WIL < 10),     // ~ 13.2

        new NarrativeTrait("Ghostlike",     90,     c => c.STR < 9 && c.AGI > 17),      // ~ 04.9
        new NarrativeTrait("Crippled",      94,     c => c.STR < 9 && c.AGI < 9),       // ~ 03.0
        new NarrativeTrait("Bookish",       76,     c => c.STR < 11 && c.INT > 15),     // ~ 12.2
        
        new NarrativeTrait("Ambidextrous",  85,     c => c.DEX > 18 && c.AGI > 13),     // ~ 07.8
        new NarrativeTrait("Crafty",        32,     c => c.DEX > 14 && c.INT > 9),      // ~ 33.9
        new NarrativeTrait("Cunning",       43,     c => c.DEX > 11 && c.INT > 14),     // ~ 28.4
        new NarrativeTrait("Tracker",       57,     c => c.DEX > 15 && c.WIS > 12),     // ~ 21.5
        new NarrativeTrait("Deep Seer",     65,     c => c.DEX > 12 && c.WIS > 16),     // ~ 17.2

        new NarrativeTrait("Alert",         49,     c => c.AGI > 14 && c.WIS > 12),     // ~ 25.5
        new NarrativeTrait("Evasive",       61,     c => c.AGI > 16 && c.WIL > 11),     // ~ 19.4
        new NarrativeTrait("Dashing",       62,     c => c.AGI > 13 && c.CHA > 15),     // ~ 19.0

        new NarrativeTrait("Aimless",       87,     c => c.AGI < 11 && c.WIS < 10),     // ~ 06.3

        new NarrativeTrait("Honorable",     29,     c => c.INT > 10 && c.WIS > 13),     // ~ 35.6
        new NarrativeTrait("Oracular",      80,     c => c.INT > 14 && c.WIS > 17),     // ~ 10.1
        new NarrativeTrait("Vengeful",      80,     c => c.INT > 16 && c.WIS < 11),     // ~ 10.0
        new NarrativeTrait("Curious",       83,     c => c.INT > 12 && c.WIS < 8),      // ~ 08.5
        new NarrativeTrait("Zealous",       67,     c => c.INT > 14 && c.WIL > 15),     // ~ 16.5
        new NarrativeTrait("Silver-Tongued",55,     c => c.INT > 13 && c.CHA > 14),     // ~ 22.6
        new NarrativeTrait("Cerebral",      71,     c => c.INT > 14 && c.CHA < 11),     // ~ 14.4

        new NarrativeTrait("Stubborn",      85,     c => c.INT < 11 && c.WIS < 11),     // ~ 07.8
        new NarrativeTrait("Barbaric",      82,     c => c.INT < 10 && c.CHA < 13),     // ~ 09.0
        new NarrativeTrait("Impolite",      86,     c => c.INT < 13 && c.CHA < 9),      // ~ 06.9
        
        new NarrativeTrait("Resolute",      49,     c => c.WIS > 12 && c.WIL > 14),     // ~ 25.6
        new NarrativeTrait("Natural Leader",52,     c => c.WIS > 11 && c.CHA > 15),     // ~ 24.0
        new NarrativeTrait("Quiet",         71,     c => c.WIS > 12 && c.CHA < 10),     // ~ 14.7

        new NarrativeTrait("Pragmatic",     66,     c => c.WIS < 12 && c.WIL > 14),     // ~ 17.0

        new NarrativeTrait("Inspiring",     69,     c => c.WIL > 16 && c.CHA > 13),     // ~ 15.4
        new NarrativeTrait("Persuasive",    65,     c => c.WIL > 12 && c.CHA > 16),     // ~ 17.3
        new NarrativeTrait("Stoic",         66,     c => c.WIL > 15 && c.CHA < 13),     // ~ 16.8


        // Other traits
        new NarrativeTrait("Average",       100,    c =>
        {
            int averageCount = 0;
            foreach (Stat stat in c.AllStats)
            {
                if (stat.Value > 10 && stat.Value < 15) averageCount++;
            }
            return averageCount > 5;
        }), // ~ 00.4

        new NarrativeTrait("Misfit",        99,     c =>
        {
            int lowCount = 0;
            foreach (Stat stat in c.AllStats)
            {
                if (stat.Value < 10) lowCount++;
            }
            return lowCount > 4;
        }), // ~ 00.5
        
        new NarrativeTrait("Allrounder",    95,     c =>
        {
            int highCount = 0;
            foreach (Stat stat in c.AllStats)
            {
                if (stat.Value > 16) highCount++;
            }
            return highCount > 4;
        }), // ~ 04.5

        new NarrativeTrait("Possessed",     666,    c =>
        {
            int sixCount = 0;
            foreach (Stat stat in c.AllStats)
            {
                if (stat.Value == 6) sixCount++;
            }
            return sixCount == 3;
        }), // ~ 00.2
    };

    public static List<NarrativeTrait> GetTraits(CharacterStats stats)
    {
        List<NarrativeTrait> matchingTraits = traits
            .Where(t => t.Condition(stats))
            .OrderByDescending(t => t.Priority)
            .ToList();

        return matchingTraits.GetRange(0, UnityEngine.Mathf.Min(matchingTraits.Count, MAX_TRAIT_COUNT));
    }

}