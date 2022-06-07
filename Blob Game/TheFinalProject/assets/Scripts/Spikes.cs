using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	public int health;
	public int maxHealth;
	
    private Player player;
	
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

	void Update()
	{
		if(health <= 0)
        {
            Destroy(gameObject);
        }
	}
	
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);
        }
    }
	
	public void Damage(int dmg)
    {
        health -= dmg;
        gameObject.GetComponent<Animation>().Play("Turret_hurt");
    }
}
