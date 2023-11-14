using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardRotate : MonoBehaviour
{
    public float tiltAmount = 30f, tiltAmountForward = 20;
    public float maxTilt = 45f;
    public float minTilt = -45f;

    public float maxTiltForward = 10f;
    public float minTiltForward = -10f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Inclinar la patineta en el eje Z al girar, limitando el giro
        float tilt = -horizontalInput * tiltAmount;

        tilt = Mathf.Clamp(tilt, minTilt, maxTilt);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, tilt);
        
        float tilt1 = verticalInput * tiltAmountForward;

        tilt1 = Mathf.Clamp(tilt1, minTiltForward, maxTiltForward);
        transform.rotation = Quaternion.Euler(tilt1, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
