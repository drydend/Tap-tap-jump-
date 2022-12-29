using System.Collections.Generic;

public class SaveData
{
    public int LastLevelNumber { get; set; }
    public bool IsTutorialCompleated { get; set; }

    public Dictionary<int, LevelData> LevelsData { get; set; }

    public Settings Settings { get; set; }

    public SaveData(int levelNumber , bool isTutorialCompleated
        , Dictionary<int, LevelData> levelsData, Settings settings)
    {
        LastLevelNumber = levelNumber;
        IsTutorialCompleated = isTutorialCompleated;
        LevelsData = levelsData;
        Settings = settings;    
    }

    public SaveData()
    {
        LastLevelNumber = 1;
        IsTutorialCompleated = false;

        LevelsData = new Dictionary<int, LevelData>();

        LevelsData[1] = new LevelData(true, false);

        Settings = new Settings();

        for (int i = 2; i <= Game.LevelsNumber; i++)
        {
            LevelsData[i] = new LevelData(true, false);
        }
    }
}