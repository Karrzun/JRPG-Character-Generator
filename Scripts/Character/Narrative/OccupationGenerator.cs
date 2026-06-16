using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


public static class OccupationGenerator
{
    public static readonly List<NarrativeOccupation> occupations = new List<NarrativeOccupation>
    {
        // Farmers, fishers and hunters (historically 80 % --> here 45 %)
        new NarrativeOccupation { Name = "Farmer", CanBeFemale = true, CanBeMale = true, Weight = 10.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Suburban, LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.Flatland, LocationTag.River } },

        new NarrativeOccupation { Name = "Fisher", CanBeFemale = true, CanBeMale = true, Weight = 9.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.Coast, LocationTag.River, LocationTag.Island } },

        new NarrativeOccupation { Name = "Hunter", CanBeFemale = true, CanBeMale = true, Weight = 5.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.Forest, LocationTag.Mountain } },


        // Artisans (10 --> 22.5 %)
        new NarrativeOccupation { Name = "Artisan", CanBeFemale = true, CanBeMale = true, Weight = 4.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Carpenter", CanBeFemale = true, CanBeMale = true, Weight = 4.0f,
            ReqDensity = null,
            ReqGeography = null },

        new NarrativeOccupation { Name = "Blacksmith", CanBeFemale = true, CanBeMale = true, Weight = 5.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Potter", CanBeFemale = true, CanBeMale = true, Weight = 4.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Suburban, LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.Forest, LocationTag.River } },

        new NarrativeOccupation { Name = "Tanner", CanBeFemale = true, CanBeMale = true, Weight = 2.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Suburban, LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.River, LocationTag.Coast } },

        new NarrativeOccupation { Name = "Paper Maker", CanBeFemale = true, CanBeMale = true, Weight = 2.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Suburban, LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.River, LocationTag.Coast, LocationTag.Forest } },

        new NarrativeOccupation { Name = "Dyer", CanBeFemale = true, CanBeMale = true, Weight = 2.5f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = new List<LocationTag> { LocationTag.River, LocationTag.Coast } },


        // Services (5 --> 20.5 %)
        new NarrativeOccupation { Name = "Merchant", CanBeFemale = true, CanBeMale = true, Weight = 3.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Monk", CanBeFemale = true, CanBeMale = true, Weight = 3.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.Mountain, LocationTag.Forest, LocationTag.Temple } },

        new NarrativeOccupation { Name = "Entertainer", CanBeFemale = true, CanBeMale = true, Weight = 2.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Servant", CanBeFemale = true, CanBeMale = true, Weight = 2.0f,
            ReqDensity = null,
            ReqGeography = new List<LocationTag> { LocationTag.Castle, LocationTag.Temple } },

        new NarrativeOccupation { Name = "Tea Master", CanBeFemale = true, CanBeMale = true, Weight = 1.5f,
            ReqDensity = null,
            ReqGeography = new List<LocationTag> { LocationTag.Castle, LocationTag.Temple } },

        new NarrativeOccupation { Name = "Innkeeper", CanBeFemale = true, CanBeMale = true, Weight = 1.0f,
            ReqDensity = null,
            ReqGeography = null },

        new NarrativeOccupation { Name = "Courier", CanBeFemale = true, CanBeMale = true, Weight = 1.5f,
            ReqDensity = null,
            ReqGeography = null },

        new NarrativeOccupation { Name = "Ferryman", CanBeFemale = false, CanBeMale = true, Weight = 2.5f,
            ReqDensity = new List<LocationTag> { LocationTag.Suburban, LocationTag.Rural },
            ReqGeography = new List<LocationTag> { LocationTag.Coast, LocationTag.River, LocationTag.Island } },

        new NarrativeOccupation { Name = "Executioner", CanBeFemale = false, CanBeMale = true, Weight = 2.5f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Courtesan", CanBeFemale = true, CanBeMale = false, Weight = 4.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Healer", CanBeFemale = false, CanBeMale = true, Weight = 1.5f,
            ReqDensity = null,
            ReqGeography = null },

        new NarrativeOccupation { Name = "Midwife", CanBeFemale = true, CanBeMale = false, Weight = 1.5f,
            ReqDensity = null,
            ReqGeography = null },

        new NarrativeOccupation { Name = "Hawker", CanBeFemale = true, CanBeMale = true, Weight = 4.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Gambler", CanBeFemale = true, CanBeMale = true, Weight = 2.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban, LocationTag.Suburban },
            ReqGeography = null },

        new NarrativeOccupation { Name = "Teacher", CanBeFemale = true, CanBeMale = true, Weight = 3.0f,
            ReqDensity = new List<LocationTag> { LocationTag.Urban },
            ReqGeography = null },


        // Military (5 --> 12 %)
        new NarrativeOccupation { Name = "Samurai", CanBeFemale = true, CanBeMale = true, Weight = 3.5f,
            ReqDensity = null,
            ReqGeography = new List<LocationTag> { LocationTag.Castle } },

        new NarrativeOccupation { Name = "Soldier", CanBeFemale = false, CanBeMale = true, Weight = 6.0f,
            ReqDensity = null,
            ReqGeography = null },
    };


    public static NarrativeOccupation GetOccupationFromOrigin(NarrativeLocation origin, Sex sex)
    {
        List<NarrativeOccupation> candidates = occupations
            .Where(occupation =>
                IsOccupationAllowedForSex(occupation, sex) &&
                HasRequiredTag(occupation.ReqDensity, origin.Tags) &&
                HasRequiredTag(occupation.ReqGeography, origin.Tags)
            )
            .ToList();

        float totalWeight = candidates.Sum(o => o.Weight);
        float rand = (float)SeanWelton.Random.Double(0d, totalWeight);
        float cumulative = 0f;

        foreach (NarrativeOccupation occupation in candidates)
        {
            cumulative += occupation.Weight;
            if (rand < cumulative)
            {
                return occupation;
            }
        }

        // Fallback (should never happen if weights are valid)
        UnityEngine.Debug.LogError("Occupation Generation went wrong!");
        return candidates[0];
    }

    private static bool IsOccupationAllowedForSex(NarrativeOccupation occupation, Sex sex)
    {
        return sex switch
        {
            Sex.Female => occupation.CanBeFemale,
            Sex.Male => occupation.CanBeMale,
            Sex.Diverse or Sex.None => occupation.CanBeFemale || occupation.CanBeMale,
            _ => false
        };
    }

    private static bool HasRequiredTag(List<LocationTag> requiredTags, List<LocationTag> givenTags)
    {
        if (requiredTags == null || requiredTags.Count == 0)
            return true;

        foreach (LocationTag tag in requiredTags)
        {
            if (givenTags.Contains(tag))
                return true;
        }
        return false;
    }

}