using UnityEngine;

public class HighlightPiece : MonoBehaviour
{
    public Material highlightMaterial; // Asigna el material de resaltado en el inspector
    public ViewControl objectInteraction; // Asigna el script ObjectInteraction en el inspector

    private Material originalMaterial;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    void OnMouseEnter()
    {
            renderer.material = highlightMaterial;
    }

    void OnMouseExit()
    {
        renderer.material = originalMaterial;
    }
}
