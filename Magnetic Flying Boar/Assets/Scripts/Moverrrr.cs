using System.Collections;
using UnityEngine;

public class Moverrrr : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;

    void Start()
    {
        MoveObject(startPoint.position);
    }

    public void MoveObjectToPointA()
    {
        MoveObject(startPoint.position);
    }

    public void MoveObjectToPointB()
    {
        MoveObject(endPoint.position);
    }

    IEnumerator MoveRoutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            yield return null;
        }

        transform.position = targetPosition;
    }

    void MoveObject(Vector3 targetPosition)
    {
        StopAllCoroutines();

        StartCoroutine(MoveRoutine(targetPosition));
    }
}