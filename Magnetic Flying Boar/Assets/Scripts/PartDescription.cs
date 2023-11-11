using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDescription : MonoBehaviour
{

    private bool flag =false;
    public TextGenerator textGenerator;
    public GameObject cuadroUI; // Asigna tu objeto UI (el cuadro) a esta variable desde el Inspector.

    private bool ratonSobreObjeto = false;

    private void Update()
    {
        if (ratonSobreObjeto)
        {
            cuadroUI.SetActive(true);
               if (textGenerator != null && !flag )
        {
            flag=true;
           StartCoroutine(TextGen());
        }

        }
        else
        {
            flag = false;
            textGenerator.dialogueText.text = "";
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
        private IEnumerator TextGen()
    {
         textGenerator.start=true;
         yield return new WaitForSeconds(0.05f);
         textGenerator.start=false;
    }
}
