using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDescription : MonoBehaviour
{

    private bool flag, can = true;
    public TextGenerator textGenerator;
    public GameObject cuadroUI;

    private void OnMouseEnter()
    {
        cuadroUI.SetActive(true);
        if (textGenerator != null && !flag)
        {
            flag = true;
           
        }
    }

    private void OnMouseExit()
    {
        cuadroUI.SetActive(false);
        flag = false;
        textGenerator.dialogueText.text = "";
        
    }
}
