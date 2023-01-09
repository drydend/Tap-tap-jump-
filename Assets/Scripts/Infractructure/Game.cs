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

    private Settings _settings;

    public int CurrentLevelNumber { get; private set; }
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

        LastUnlockedLevel = saveData.LastLevelNumber;
        LevelsData = saveData.LevelsData;
        IsTutorialCompleated = saveData.IsTutorialCompleated;
        _settings = saveData.Settings;

        _sceneLoader.LoadSceneAsInitial(MainMenuSceneName);
    }

    public void LoadMainMenu()
    {
        if (_sceneLoader.IsLoading)
        {
            return;
        }

        _sceneLoader.LoadScene(MainMenuSceneName);
    }

    public void PlayLevel(int levelNumber)
    {
        if (_sceneLoader.IsLoading)
        {
            return;
        }

        if (levelNumber > LevelsNumber)
        {
            throw new Exception($"Can not launch level #{levelNumber}");
        }

        CurrentLevelNumber = levelNumber;

        if (IsTutorialCompleated)
        {
            StartCurrentLevel();
        }
        else
        {
            StartTutorial();
        }
    }

    public void RestartLevel()
    {
        if (_sceneLoader.IsLoading)
        {
            return;
        }

        StartCurrentLevel();
    }

    public void StartNextLevel()
    {
        if (_sceneLoader.IsLoading)
        {
            return;
        }

        if (CurrentLevelNumber >= LevelsNumber)
        {
            return;
        }

        CurrentLevelNumber++;
        StartCurrentLevel();
    }

    public void OnTutorialCompleated()
    {
        IsTutorialCompleated = true;
    }

    public void OnCurrentLevelCompleated(float completeTime)
    {
        if (CurrentLevelNumber == LastUnlockedLevel && LastUnlockedLevel <= LevelsNumber)
        {
            LastUnlockedLevel++;
            LevelsData[LastUnlockedLevel].Unlock();
        }

        if(LevelsData[CurrentLevelNumber].BestCompleteTime > completeTime)
        {
            completeTime = LevelsData[CurrentLevelNumber].BestCompleteTime;
        }

        LevelsData[CurrentLevelNumber] = new LevelData(true, true, completeTime);
    }

    public void StartCurrentLevel()
    {
        if (_sceneLoader.IsLoading)
        {
            return;
        }

        _sceneLoader.LoadScene(LevelNamePrefix + CurrentLevelNumber.ToString());
    }

    private void StartTutorial()
    {
        if (_sceneLoader.IsLoading)
        {
            return;
        }

        _sceneLoader.LoadScene(TutorialSceneName);
    }

    private void Save()
    {
        var saveData = new SaveData(LastUnlockedLevel, IsTutorialCompleated, LevelsData, _settings);
        _saveService.Save(saveData);
    }
}
