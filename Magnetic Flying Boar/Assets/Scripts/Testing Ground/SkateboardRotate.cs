using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardRotate : MonoBehaviour
{
    public float tiltAmount = 30f;
    public float maxTilt = 45f;
    public float minTilt = -45f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Inclinar la patineta en el eje Z al girar, limitando el giro
        float tilt = -horizontalInput * tiltAmount;
        tilt = Mathf.Clamp(tilt, minTilt, maxTilt);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, tilt);

    }
}
