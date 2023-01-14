using System;
using System.Collections.Generic;

[Serializable]
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
        LevelsData = new Dictionary<int, LevelData>();

        IsTutorialCompleated = false;
        Settings = new Settings();

        LastLevelNumber = 1;
        LevelsData[1] = new LevelData(true, false, 0);


        for (int i = 2; i <= Game.LevelsNumber; i++)
        {
            LevelsData[i] = new LevelData(false, false, 0);
        }
    }
}