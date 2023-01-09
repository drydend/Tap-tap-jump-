using UnityEngine;
public class CameraScaler
{
    private float _cameraInitialSize;
    private float _desiredCameraWifth;

    public CameraScaler(CameraConfig cameraConfig)
    {
        _cameraInitialSize = cameraConfig.CameraInitialSize;
        _desiredCameraWifth = cameraConfig.DesiredWidth;
    }

    public void ScaleCamera()
    {
        var ration = Screen.height / (float)Screen.width;
        var cameraSize = ration * _desiredCameraWifth;
        var cameraYOffSet = cameraSize - _cameraInitialSize;

        CameraFollower.SetScaleValues(cameraYOffSet, cameraSize);
    }
}
