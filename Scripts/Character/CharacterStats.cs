using SeanWelton.Stats;
using System.Collections.Generic;
using SW = SeanWelton;


[System.Serializable]
public class CharacterStats
{
    private const int MinValue = 5;
    private const int MaxValue = 20;

    public Stat Constitution;
    public Stat Strength;
    public Stat Dexterity;
    public Stat Agility;
    public Stat Intelligence;
    public Stat Wisdom;
    public Stat Willpower;
    public Stat Charisma;

    public IReadOnlyList<Stat> AllStats => new List<Stat>()
    {
        Constitution, Strength, Dexterity, Agility, Intelligence, Wisdom, Willpower, Charisma
    }.AsReadOnly();

    public float CON => Constitution.Value;
    public float STR => Strength.Value;
    public float DEX => Dexterity.Value;
    public float AGI => Agility.Value;
    public float INT => Intelligence.Value;
    public float WIS => Wisdom.Value;
    public float WIL => Willpower.Value;
    public float CHA => Charisma.Value;
    public float Sum => CON + STR + DEX + AGI + INT + WIS + WIL + CHA;


    public CharacterStats(int con, int str, int dex, int agi, int intel, int wis, int will, int cha)
    {
        Constitution = new Stat(con);
        Strength = new Stat(str);
        Dexterity = new Stat(dex);
        Agility = new Stat(agi);
        Intelligence = new Stat(intel);
        Wisdom = new Stat(wis);
        Willpower = new Stat(will);
        Charisma = new Stat(cha);
    }

    public CharacterStats() : this(GetRandomStatValue(), GetRandomStatValue(), GetRandomStatValue(), GetRandomStatValue(), GetRandomStatValue(), GetRandomStatValue(), GetRandomStatValue(), GetRandomStatValue())
    { }

    private static int GetRandomStatValue()
    {
        return SW.Random.Integer(MinValue, MaxValue + 1);
    }

    public override string ToString()
    {
        return $"CON: {CON}, STR: {STR}, DEX: {DEX}, AGI: {AGI}, INT: {INT}, WIS: {WIS}, WILL: {WIL}, CHA: {CHA}";
    }
}