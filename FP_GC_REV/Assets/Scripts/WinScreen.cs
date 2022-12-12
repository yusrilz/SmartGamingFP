using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public static bool isOver = false;
    public void Setup()
    {
        gameObject.SetActive(true);
        isOver = true;
    }
}

