using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Transform theCamera;
    public Camera cameraForPOV;
    public float smoothSpeed = .125f;
    public float cameraDistance = 30f;
    public Vector3 offset;
    private Vector3 desiredPosition, smoothedPosition;

    private void Awake()
    {
        cameraForPOV.orthographicSize = ((Screen.height / 2) / cameraDistance);
    }
    private void FixedUpdate()
    {
        desiredPosition = target.position + offset;
        smoothedPosition = Vector3.Lerp(target.position, desiredPosition, smoothSpeed);
        theCamera.position = smoothedPosition;
        theCamera.LookAt(target);
    }

}
