using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float initialDistance = 5.0f;
    public float rotationSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float zoomSpeed = 2.0f;

    public Camera cameraToOscillate; // C�mara que oscilar� alrededor del objetivo

    [SerializeField] private Transform target; // Objeto que la c�mara observa

    private Vector3 offset;
    private float horizontalAngle = 0.0f;
    private float verticalAngle = 0.0f;
    private bool isRightMousePressed = false;

    private void Start()
    {
        offset = new Vector3(0.0f, 0.0f, -initialDistance);
    }

    private void LateUpdate()
    {
        HandleMouseInput();
        HandleZoom();
        HandleCameraRotation();
    }

    private void HandleMouseInput()
    {
        // Detectar el clic derecho del rat�n
        if (Input.GetMouseButtonDown(1))
        {
            isRightMousePressed = true;
        }
        // Detectar la liberaci�n del clic derecho del rat�n
        else if (Input.GetMouseButtonUp(1))
        {
            isRightMousePressed = false;
        }
    }

    private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (isRightMousePressed)
        {
            // Rotar la c�mara con el movimiento del rat�n solo si el clic derecho est� presionado
            horizontalAngle += mouseX * rotationSpeed;
            verticalAngle -= mouseY * verticalSpeed;

            verticalAngle = Mathf.Clamp(verticalAngle, -80, 80);
        }

        Quaternion rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
        Vector3 newPosition = target.position + rotation * offset;

        // Detecci�n de colisiones con objetos del Tag "Obstacle"
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Obstacle"); // Ajusta "Obstacle" al nombre de tu Layer
        if (Physics.Linecast(target.position, newPosition, out hit, layerMask))
        {
            // Si hay una colisi�n con un objeto del Tag "Obstacle", ajustar la posici�n de la c�mara
            newPosition = hit.point;
        }

        cameraToOscillate.transform.position = newPosition;
        cameraToOscillate.transform.LookAt(target);
    }


    private void HandleZoom()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        initialDistance -= zoomInput * zoomSpeed;
        initialDistance = Mathf.Clamp(initialDistance, 2.0f, 10.0f);
        offset.z = -initialDistance;
    }
}
