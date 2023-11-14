using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;


    void Update()
    {
        // Obtener la entrada del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Mover hacia adelante y atrás
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // Girar la patineta
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
