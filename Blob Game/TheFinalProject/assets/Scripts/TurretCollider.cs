﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollider : MonoBehaviour
{

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);
        }
    }
}