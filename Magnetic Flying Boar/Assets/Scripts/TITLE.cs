using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TITLE : MonoBehaviour
{
    public List<TextGenerator> generatorList = new List<TextGenerator>();
    void Start()
    {
        foreach (var generator in generatorList)
            generator.InitText();
    }

}
