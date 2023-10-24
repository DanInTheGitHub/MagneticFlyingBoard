using UnityEngine;

public class ChangeCameraTarget : MonoBehaviour
{
    public ViewControl objectInteraction; // Asigna el objeto con el script ObjectInteraction

    private void OnMouseDown()
    {
        objectInteraction.ChangeTarget(transform);
    }
}
