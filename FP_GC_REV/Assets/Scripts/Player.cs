using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private float enemyDamage = 1f;
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
            currentHealth -= enemyDamage;
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
