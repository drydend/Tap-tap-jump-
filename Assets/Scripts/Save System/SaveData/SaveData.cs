using System.Collections.Generic;
using UnityEditor.TextCore.Text;

public class SaveData
{
    public int LastLevelNumber { get; set; }
    public bool IsTutorialCompleated { get; set; }

    public Dictionary<int, LevelData> LevelsData { get; set; }

    public SaveData(int levelNumber , bool isTutorialCompleated, Dictionary<int, LevelData> levelsData)
    {
        LastLevelNumber = levelNumber;
        IsTutorialCompleated = isTutorialCompleated;
        LevelsData = levelsData;
    }

    public SaveData()
    {
        LastLevelNumber = 1;
        IsTutorialCompleated = false;

        LevelsData = new Dictionary<int, LevelData>();

        LevelsData[1] = new LevelData(true, false);

        for (int i = 2; i <= Game.LevelsNumber; i++)
        {
            LevelsData[i] = new LevelData(false, false);
        }
    }
}