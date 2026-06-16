using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Character
{
    [SerializeField] private string familyName;
    [SerializeField] private string givenName;
    [SerializeField] private Sex sex;

    [SerializeField] private CharacterStats stats;
    [SerializeField] private List<NarrativeTrait> traits;

    [SerializeField] private NarrativeLocation origin;
    [SerializeField] private NarrativeOccupation occupation;

    [SerializeField] private string description;

    public string FamilyName => familyName;
    public string GivenName => givenName;
    public string FullName => $"{familyName} {givenName}";
    public Sex Sex => sex;

    public CharacterStats Stats => stats;
    public IReadOnlyList<NarrativeTrait> Traits => traits;

    public NarrativeLocation Origin => origin;
    public NarrativeOccupation Occupation => occupation;

    public string Description => description;

    public event Action<string> DescriptionUpdated;


    public Character(string familyName, string givenName, Sex sex, CharacterStats stats, List<NarrativeTrait> traits, NarrativeLocation origin, NarrativeOccupation occupation, string description = "")
    {
        this.familyName = familyName;
        this.givenName = givenName;
        this.sex = sex;
        this.stats = stats;
        this.traits = traits ?? new List<NarrativeTrait>();
        this.origin = origin;
        this.occupation = occupation;
        this.description = description;
    }

    public void SetDescription(string newDescription)
    {
        description = CharacterDescriptionFormatter.Format(newDescription);
        DescriptionUpdated?.Invoke(description);
    }

    public override string ToString()
    {
        return $"{FullName} ({Sex}), {Occupation.Name} from {Origin.Name}";
    }

}