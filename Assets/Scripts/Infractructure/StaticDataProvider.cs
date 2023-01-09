using UnityEngine;

public class StaticDataProvider : MonoBehaviour
{
    [SerializeField]
    private LevelCompleateTimings _levelTimings;
    [SerializeField]
    private CameraConfig _cameraConfig;

    public LevelCompleateTimings LevelCompleteTimings => _levelTimings;

    public CameraConfig CameraConfig => _cameraConfig;
}
