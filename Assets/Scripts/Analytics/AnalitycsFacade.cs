using Firebase;
using Firebase.Analytics;
using System;
using UnityEngine;

public class AnalitycsFacade
{
    private FirebaseApp _app;
    private bool _isReadyToUse;

    private Game _game;
    public AnalitycsFacade(Game game)
    {
        _game = game;
    }

    public async void SetupAnalitycs()
    {
        await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                _app = FirebaseApp.DefaultInstance;
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                _isReadyToUse = true;
                Debug.Log("Analitycs ready to use");
            }
            else
            {
                _isReadyToUse = false;
                Debug.LogError(String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }

    public void LogPlayerDeath()
    {
        if (_isReadyToUse)
        {
            FirebaseAnalytics.LogEvent("Player died", "level number", _game.CurrentLevelNumber);
        }
    }

    public void LogLevelCompleation(float completeTime)
    {
        if (_isReadyToUse)
        {
            FirebaseAnalytics.LogEvent("Level compleated", "level number/compleate time",
                $"{_game.CurrentLevelNumber} / {completeTime}");
        }
    }
}
