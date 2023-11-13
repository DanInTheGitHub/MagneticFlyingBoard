using System.Collections;
using UnityEngine;

public class ViewControl : MonoBehaviour
{
    public float initialDistance = 5.0f;
    public float rotationSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float zoomSpeed = 2.0f;

    public float separationSpeed = 0.5f; // Velocidad de separaci�n
    public float joinSpeed = 0.5f; // Velocidad de uni�n

    public GameObject parentObject; // El objeto completo que contiene todas las piezas
    public Camera cameraToOscillate; // C�mara que oscilar� alrededor del objetivo

    public GameObject[] piecesUp;
    public GameObject[] piecesDown;
    public GameObject[] piecesStatic;

    [SerializeField] private Transform target; // Objeto que la c�mara observa
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
            StartCoroutine(SeparatePieces());
        }
    }

    public void Join()
    {
        if (!canSeparate)
        {
            StartCoroutine(JoinPieces());
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

        // Restablece el objetivo a la c�mara
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

    private IEnumerator SeparatePieces()
    {
        float separationTime = 2.0f; // Tiempo total para separar las piezas
        float startTime = Time.time;
        while (Time.time - startTime < separationTime)
        {
            for (int i = 1; i < piecesUp.Length; i++)
            {
                piecesUp[i].transform.Translate(Vector3.forward * 2.0f * i * Time.deltaTime * separationSpeed);
                piecesDown[i].transform.Translate(Vector3.back * 2.0f * i * Time.deltaTime * separationSpeed);
                yield return null; // Espera un frame antes de continuar
            }
        }

        canSeparate = false;
    }

    private IEnumerator JoinPieces()
    {
        float joinTime = 2.0f; // Tiempo total para separar las piezas
        float startTime = Time.time;

        while (Time.time - startTime < joinTime)
        {
            for (int i = piecesUp.Length - 1; i > 0; i--)
            {
                piecesUp[i].transform.Translate(Vector3.back * 2.0f * i * Time.deltaTime * joinSpeed);
                piecesDown[i].transform.Translate(Vector3.forward * 2.0f * i * Time.deltaTime * joinSpeed);
                yield return null;
            }
        }

        canSeparate = true;
    }
}