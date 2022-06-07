using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour {

    public TurretAI ai;

    public bool isLeft = false;

    void Awake()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                ai.Attack(false);
            }
            else
            {
                ai.Attack(true);
            }
        }
    }
}
