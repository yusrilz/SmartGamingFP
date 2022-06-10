using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Healthbar healthbar;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D co)
    {
        if (co.gameObject.tag == "Enemy")
        {
            Debug.Log("Aku kena Enemy Gais");
            currentHealth -= Random.Range(2f, 5f);
            healthbar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            //FindObjectOfType<GameManager>().Paused();
        //}
    }
}
