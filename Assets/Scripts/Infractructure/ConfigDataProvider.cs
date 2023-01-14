using UnityEngine;

public class ConfigDataProvider : MonoBehaviour
{
    [SerializeField]
    private LevelCompleateTimings _levelTimings;
    [SerializeField]
    private CameraConfig _cameraConfig;

    public LevelCompleateTimings LevelCompleteTimings => _levelTimings;

    public CameraConfig CameraConfig => _cameraConfig;
}
