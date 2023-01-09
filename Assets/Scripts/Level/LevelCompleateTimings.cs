using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Complete Timings", fileName = "Level Complete Timings")]
public class LevelCompleateTimings : ScriptableObject
{
    [SerializeField]
    private List<float> _timings;
    public float this[int levelIndex]
    {
        get
        {
            return _timings[levelIndex];
        }
    }
}