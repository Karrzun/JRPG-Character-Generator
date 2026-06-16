using System.Collections.Generic;

[System.Serializable]
public struct NarrativeOccupation
{
    public string Name;
    public string JapaneseName;

    public bool CanBeFemale;
    public bool CanBeMale;

    public float Weight;

    public List<LocationTag> ReqDensity;
    public List<LocationTag> ReqGeography;


    public override string ToString()
    {
        return Name;
    }
}