using UnityEngine;

public class ViewControl : MonoBehaviour
{
    public GameObject[] piecesUp;
    public GameObject[] piecesDown;
    public GameObject[] piecesStatic;

    [SerializeField] private bool canSeparate = false;

    private Vector3[] originalPositionsUp;
    private Vector3[] originalPositionsDown;

    private void Start()
    {
        canSeparate = true;
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
}
