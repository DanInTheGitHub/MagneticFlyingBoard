using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : MonoBehaviour
{

    private bool flag =false;
    public List <TextGenerator> textGenerators = new List<TextGenerator>();
    public GameObject cuadroUI; // Asigna tu objeto UI (el cuadro) a esta variable desde el Inspector.

    private bool ratonSobreObjeto = false;

    private void Update()
    {
        if (ratonSobreObjeto)
        {
            cuadroUI.SetActive(true);
            foreach (var textGenerator in textGenerators) 
            {
               if (textGenerator != null && !flag )
                {
                flag=true;
            StartCoroutine(TextGen());
                }
            }
           

        }
        else
        {
            flag = false;
            foreach (var textGenerator in textGenerators) 
            {
                textGenerator.dialogueText.text = "";
            }
       
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
        foreach (var textGenerator in textGenerators) 
            {
         textGenerator.start=true;
            }
         yield return new WaitForSeconds(0.05f);
         foreach (var textGenerator in textGenerators) 
            {
         textGenerator.start=false;
            }   
    }
}
