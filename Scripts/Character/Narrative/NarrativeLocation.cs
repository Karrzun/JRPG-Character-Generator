using System.Collections.Generic;


[System.Serializable]
public struct NarrativeLocation
{
    public string Name;
    public List<LocationTag> Tags;

    public override string ToString()
    {
        return Name;
    }
}


[System.Serializable]
public enum LocationTag
{
    None = -10,
    Urban = 0,
    Suburban = 1,
    Rural = 2,
    Temple = 3,
    Castle = 4,
    Mountain = 10,
    Flatland = 11,
    Coast = 12,
    River = 20,
    Forest = 21,
    Island = 22,
}