using UnityEngine;

public class ViewControl : MonoBehaviour
{
    public float initialDistance = 5.0f;
    public float rotationSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float zoomSpeed = 2.0f;

    public GameObject parentObject; // El objeto completo que contiene todas las piezas
    public Camera cameraToOscillate; // Cámara que oscilará alrededor del objetivo

    public GameObject[] piecesUp;
    public GameObject[] piecesDown;
    public GameObject[] piecesStatic;

    [SerializeField] private Transform target; // Objeto que la cámara observa
    [SerializeField] private bool canSeparate = false;

    private Vector3 offset;
    private float horizontalAngle = 0.0f;
    private float verticalAngle = 0.0f;
    private Vector3[] originalPositionsUp;
    private Vector3[] originalPositionsDown;

    private bool allPiecesVisible = true;

    private void Start()
    {
        offset = new Vector3(0.0f, 0.0f, -initialDistance);
        canSeparate = true;
        target = parentObject.transform; // Inicialmente, el objetivo es el objeto completo
        ToggleAllPiecesVisibility(allPiecesVisible);
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

    public void Separate()
    {
        if (canSeparate)
        {
            if (originalPositionsUp == null)
            {
                originalPositionsUp = new Vector3[piecesUp.Length];
                for (int i = 0; i < piecesUp.Length; i++)
                {
                    originalPositionsUp[i] = piecesUp[i].transform.position;
                }
            }

            if (originalPositionsDown == null)
            {
                originalPositionsDown = new Vector3[piecesDown.Length];
                for (int i = 0; i < piecesDown.Length; i++)
                {
                    originalPositionsDown[i] = piecesDown[i].transform.position;
                }
            }

            for (int i = 1; i < piecesUp.Length; i++)
            {
                piecesUp[i].transform.Translate(Vector3.forward * 2.0f * i);
            }

            for (int i = 1; i < piecesDown.Length; i++)
            {
                piecesDown[i].transform.Translate(Vector3.back * 2.0f * i);
            }

            canSeparate = false;
        }
    }

    public void Join()
    {
        if (!canSeparate)
        {
            for (int i = 0; i < piecesUp.Length; i++)
            {
                piecesUp[i].transform.position = originalPositionsUp[i];
            }

            for (int i = 0; i < piecesDown.Length; i++)
            {
                piecesDown[i].transform.position = originalPositionsDown[i];
            }

            canSeparate = true;
        }
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;

        // Oculta todas las piezas
        ToggleAllPiecesVisibility(false);

        // Muestra la pieza seleccionada
        newTarget.gameObject.SetActive(true);
    }

    public void ShowAllPieces()
    {
        // Muestra todas las piezas
        ToggleAllPiecesVisibility(true);

        // Restablece el objetivo a la cámara
        target = parentObject.transform;
    }


    private void ToggleAllPiecesVisibility(bool visible)
    {
        foreach (var piece in piecesUp)
        {
            piece.SetActive(visible);
        }

        foreach (var piece in piecesDown)
        {
            piece.SetActive(visible);
        }

        foreach (var piece in piecesStatic)
        {
            piece.SetActive(visible);
        }
    }

    public bool AreAllPiecesVisible()
    {
        bool allVisible = true;

        foreach (var piece in piecesUp)
        {
            if (!piece.activeSelf)
            {
                allVisible = false;
                break;
            }
        }

        foreach (var piece in piecesDown)
        {
            if (!piece.activeSelf)
            {
                allVisible = false;
                break;
            }
        }

        return allVisible;
    }
}