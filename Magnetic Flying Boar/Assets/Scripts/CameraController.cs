using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float initialDistance = 5.0f;
    public float rotationSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float zoomSpeed = 2.0f;

    private Vector3 offset;
    private float horizontalAngle = 0.0f;
    private float verticalAngle = 0.0f;

    private void Start()
    {
        offset = new Vector3(0.0f, 0.0f, -initialDistance);
    }

    private void LateUpdate()
    {
        HandleCameraRotation();
        HandleZoom();
    }

    private void HandleCameraRotation()
    {
        horizontalAngle += Input.GetAxis("Horizontal") * rotationSpeed;
        verticalAngle -= Input.GetAxis("Vertical") * verticalSpeed;

        verticalAngle = Mathf.Clamp(verticalAngle, -80, 80);

        Quaternion rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
        Vector3 newPosition = target.position + rotation * offset;

        transform.position = newPosition;
        transform.LookAt(target);
    }

    private void HandleZoom()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        initialDistance -= zoomInput * zoomSpeed;
        initialDistance = Mathf.Clamp(initialDistance, 2.0f, 10.0f);
        offset.z = -initialDistance;
    }
}

