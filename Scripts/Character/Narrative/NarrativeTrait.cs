public class NarrativeTrait
{
    public string Name;
    public int Priority; // Higher means more rare or interesting
    public System.Func<CharacterStats, bool> Condition;

    private const int MAX_PRIORITY_OFFSET = 5;

    public NarrativeTrait(string name, int priority, System.Func<CharacterStats, bool> condition)
    {
        Name = name;
        priority += SeanWelton.Random.Integer(-MAX_PRIORITY_OFFSET, MAX_PRIORITY_OFFSET); // some random variation
        Priority = priority;
        Condition = condition;
    }
}