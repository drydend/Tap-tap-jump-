using UnityEngine;

public class Game : ISaveable
{
    private const string LevelNamePrefix = "Level";

    private int _currentLevelNumber;
    private SceneLoader _sceneLoader;
    private SaveService _saveSerivce;

    public Game(SaveService saveSerivce, SceneLoader sceneLoader)
    {
        _saveSerivce = saveSerivce;
        _sceneLoader = sceneLoader;
    }

    public void StartGame()
    {
        _saveSerivce.SubscribeToSaving(this);

        Application.quitting += _saveSerivce.Save;
        _saveSerivce.LoadAllData();
        _currentLevelNumber = _saveSerivce.GetData<LevelNumberSaveData>().LevelNumber;

        _sceneLoader.LoadInitialLevel(LevelNamePrefix + _currentLevelNumber.ToString());
    }

    public void RestartLevel()
    {
        _saveSerivce.Save();
        _sceneLoader.LoadInitialLevel(LevelNamePrefix + _currentLevelNumber.ToString());
    }

    public void StartNextLevel()
    {
        _currentLevelNumber++;
        _saveSerivce.Save();
        _sceneLoader.LoadLevel(LevelNamePrefix + _currentLevelNumber.ToString());
    }

    public SaveData GetSaveData()
    {
        return new LevelNumberSaveData(_currentLevelNumber);
    }
}
