using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCooldown = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("m") && !attacking && !anim.GetBool("Hurt"))
        {
            attacking = true;

            attackTimer = attackCooldown;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;

            }
        }

        anim.SetBool("Attacking", attacking);
    }

    
}
