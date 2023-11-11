using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
public class TextGenerator : MonoBehaviour
{
    [SerializeField] public bool start;  
    [SerializeField] private float delay = 0.4f;
    [SerializeField] public TMP_Text dialogueText;
    [SerializeField] private List<string> linesMessage = new List<string>();
    private bool isScripting;
    void Awake()
    {
        dialogueText.text = "";
    }

    private void Update()
    {
       
        if (start && !isScripting)
        {
            start = false;
            StartCoroutine(ScriptText());
        }
    }
    
    private IEnumerator ScriptText()
    {
        if (isScripting) yield break;
        isScripting = true;
        foreach (string lines in linesMessage)
        {
            foreach (char letter in lines)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(delay);
            }
            dialogueText.text += "\n";
        }
        isScripting = false;
    }
}
