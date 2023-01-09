using UnityEngine;

[CreateAssetMenu(menuName ="Camera Config" , fileName = "Camera Config")]
public class CameraConfig : ScriptableObject
{
    [SerializeField]
    private float _cameraInitialSize = 25f;
    [SerializeField]
    private float _desiredWidth = 14.065f;

    public float CameraInitialSize => _cameraInitialSize;
    public float DesiredWidth => _desiredWidth;
}