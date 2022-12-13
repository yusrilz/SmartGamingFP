using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public SceneTransition sceneTransitionManager;
    public void Next()
    {
        StartCoroutine(sceneTransitionManager.LoadLevel());
    }
}
