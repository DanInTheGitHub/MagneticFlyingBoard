using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControler : MonoBehaviour
{
    public GameObject text;
    public float setActiveTime = 2.0f;
    private bool hide = false;
    private float timeElapsed = 0.0f;

    private void Start()
    {
        text.SetActive(false);
    }

    private void Update()
    {
        if (!hide)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= setActiveTime)
            {
                hide = true;
                timeElapsed = 0.0f;
                text.SetActive(true);
            }
        }
        else
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= setActiveTime)
            {
                hide = false;
                timeElapsed = 0.0f;
                text.SetActive(false);
            }
        }
    }
}
