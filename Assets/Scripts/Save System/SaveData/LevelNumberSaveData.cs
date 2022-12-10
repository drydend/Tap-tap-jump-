public class LevelNumberSaveData : SaveData
{
    public int LevelNumber { get;private set; }

    public LevelNumberSaveData(int levelNumber)
    {
        LevelNumber = levelNumber;
    }

    public LevelNumberSaveData()
    {
        LevelNumber = 1;
    }
}
