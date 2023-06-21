using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    GameObject canvasObject = GameObject.Find("Canvas");

    private void Awake()
    {
        DontDestroyOnLoad(canvasObject);
    }
}
