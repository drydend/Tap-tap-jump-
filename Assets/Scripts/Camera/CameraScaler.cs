using UnityEngine;
public class CameraScaler
{
    private const float CameraInitialSize = 25f;
    private const float DesireCameraWidth = 14.0625f;
    
    public void ScaleCamera()
    {
        var ration = Screen.height / (float)Screen.width;
        var cameraSize = ration * DesireCameraWidth;
        var cameraYOffSet = cameraSize - CameraInitialSize;

        CameraFollower.SetScaleValues(cameraYOffSet, cameraSize);
    }
}
