using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : MonoBehaviour
{

    private bool flag = false;
    public List <TextGenerator> textGenerators = new List<TextGenerator>();
    public GameObject cuadroUI; // Asigna tu objeto UI (el cuadro) a esta variable desde el Inspector.


    private void OnMouseEnter()
    {
        cuadroUI.SetActive(true);
        foreach (var textGenerator in textGenerators)
           textGenerator.InitText();
    }

    private void OnMouseExit()
    {
        flag = false;
        foreach (var textGenerator in textGenerators)
            textGenerator.dialogueText.text = "";
        
        cuadroUI.SetActive(false);

    }
}
