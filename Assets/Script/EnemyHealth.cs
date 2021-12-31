using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private Animator anim;
    private int currentHealth;
    public bool isDead = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("attacked");
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            EnemyDied();
            if (gameObject.name == "Boss")
            {
                GameObject.Find("Cage").SetActive(false);
            }
        }
    }

    private void EnemyDied()
    {
        // print("Enemy died");
        SoundManager.PlaySound("enemyDeath");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }
}
