using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float initialHealth = 1f;
    private Animator anim;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = initialHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, initialHealth);


        if (currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            GetComponent<PlayerMovement>().enabled = false;
        }


    }
}
