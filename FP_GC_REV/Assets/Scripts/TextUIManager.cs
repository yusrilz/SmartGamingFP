using UnityEngine;
using UnityEngine.UI;

public class TextUIManager : MonoBehaviour
{
    public Text enemyCountText;

    void Update()
    {
        enemyCountText.text = FindObjectOfType<GameManager>().enemyDieCount.ToString();
    }
}
