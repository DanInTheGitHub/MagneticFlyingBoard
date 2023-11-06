using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureControler : MonoBehaviour
{
    public Material[] materials;  // Arreglo de materiales
    private int currentMaterial = 0;  // Índice del material actual
    public float rotationSpeed = 30.0f;  // Velocidad de rotación en grados por segundo
    public GameObject targetObject;  // Objeto selecionado

    Renderer rend;

    void Start()
    {
        rend = targetObject.GetComponent<Renderer>();

        if (rend == null)
        {
            Debug.LogError("El objeto no tiene un Renderer válido.");
            enabled = false;
        }

        ChangeMaterial(0);
    }

    void Update()
    {
        targetObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    
    public void ChangeMaterial(int index)
    {
        if (index >= 0 && index < materials.Length)
        {
            currentMaterial = index;
            rend.material = materials[currentMaterial];
        }
        else
        {
            Debug.LogWarning("Material index out of range.");
        }
    }
}
