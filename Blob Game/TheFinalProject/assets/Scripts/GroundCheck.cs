using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<Player>();
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy") && !col.isTrigger)
        {
            player.grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy") && !col.isTrigger)
        {
            player.grounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (!col.CompareTag("Enemy") && !col.isTrigger)
        {
            player.grounded = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
