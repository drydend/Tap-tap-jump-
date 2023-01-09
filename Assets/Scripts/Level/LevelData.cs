public class LevelData 
{
    public bool IsUnlocked { get; private set; }
    public bool IsCompleated { get; private set; }
    public float BestCompleteTime { get; private set; }

    public LevelData(bool isUnlocked, bool isCompleated, float bestCompleteTime)
    {
        IsUnlocked = isUnlocked;
        IsCompleated = isCompleated;
        BestCompleteTime = bestCompleteTime;
    }

    public void Unlock()
    {
        IsUnlocked = true;
    }
}
