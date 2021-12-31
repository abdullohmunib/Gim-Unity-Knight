using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        // animasi attack
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("attacking");

            // deteksi musuh di suatu range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            attack.PlaySound("attack");

            // memberikan damage kepada musuh
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(1);
            }
        }

    }

    [SerializeField]
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
