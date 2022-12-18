using System;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public const int LevelsNumber = 50;

    private const string MainMenuSceneName = "MainMenu";
    private const string TutorialSceneName = "Tutorial";
    private const string LevelNamePrefix = "Level";

    private SceneLoader _sceneLoader;
    private SaveService _saveService;

    private int _currentLevelNumber;

    public bool IsTutorialCompleated { get; private set; }
    public int LastUnlockedLevel { get; private set; }
    public Dictionary<int, LevelData> LevelsData { get; private set; }

    public Game(SaveService saveService, SceneLoader sceneLoader)
    {
        _saveService = saveService;
        _sceneLoader = sceneLoader;
    }

    public void StartGame()
    {
        Application.quitting += Save;
        var saveData = _saveService.GetData();

#if UNITY_EDITOR
        saveData = new SaveData();
#endif

        LastUnlockedLevel = saveData.LastLevelNumber;
        LevelsData = saveData.LevelsData;
        IsTutorialCompleated = saveData.IsTutorialCompleated;

        _sceneLoader.LoadSceneAsInitial(MainMenuSceneName);
    }

    public void LoadMainMenu()
    {
        _sceneLoader.LoadScene(MainMenuSceneName);
    }

    public void PlayLevel(int levelNumber)
    {
        if (levelNumber > LevelsNumber)
        {
            throw new Exception($"Can not launch level #{levelNumber}");
        }

        _currentLevelNumber = levelNumber;

        if (!IsTutorialCompleated)
        {
            StartTutorial();
        }
        else
        {
            StartCurrentLevel();
        }
    }

    public void RestartLevel()
    {
        StartCurrentLevel();
    }

    public void StartNextLevel()
    {
        if (_currentLevelNumber >= LevelsNumber)
        {
            return;
        }

        _currentLevelNumber++;
        StartCurrentLevel();
    }

    public void OnTutorialCompleated()
    {
        IsTutorialCompleated = true;
    }

    public void OnCurrentLevelCompleated()
    {
        if (_currentLevelNumber == LastUnlockedLevel && LastUnlockedLevel <= LevelsNumber)
        {
            LastUnlockedLevel++;
            LevelsData[LastUnlockedLevel].Unlock();
        }

        LevelsData[_currentLevelNumber] = new LevelData(true, true);
    }

    public void StartCurrentLevel()
    {
        _sceneLoader.LoadScene(LevelNamePrefix + _currentLevelNumber.ToString());
    }

    private void StartTutorial()
    {
        _sceneLoader.LoadScene(TutorialSceneName);
    }

    private void Save()
    {
        var saveData = new SaveData(LastUnlockedLevel, IsTutorialCompleated, LevelsData);
        _saveService.Save(saveData);
    }
}
