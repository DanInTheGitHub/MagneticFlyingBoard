using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDescription : MonoBehaviour
{
    public GameObject cuadroUI; // Asigna tu objeto UI (el cuadro) a esta variable desde el Inspector.

    private bool ratonSobreObjeto = false;

    private void Update()
    {
        if (ratonSobreObjeto)
        {
            cuadroUI.SetActive(true);
        }
        else
        {
            cuadroUI.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        ratonSobreObjeto = true;
    }

    private void OnMouseExit()
    {
        ratonSobreObjeto = false;
    }
}
