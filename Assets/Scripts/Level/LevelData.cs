public class LevelData 
{
    public bool IsUnlocked { get; private set; }
    public bool IsCompleated { get; private set; }

    public LevelData(bool isUnlocked, bool isCompleated)
    {
        IsUnlocked = isUnlocked;
        IsCompleated = isCompleated;
    }

    public void Unlock()
    {
        IsUnlocked = true;
    }
}
