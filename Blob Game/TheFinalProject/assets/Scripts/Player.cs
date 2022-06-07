using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    // Floats
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    // Stats
    public int health;
    public int maxHealth = 100;

    // Booleans
    public bool grounded;
    public bool canDoubleJump;
    public bool invincible;

    // References
    private Rigidbody2D rb2d;
    private Animator anim;
	private gameMaster gm;

	// Use this for initialization
	void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(Input.GetButtonDown("Jump"))
        {

            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * (jumpPower * 0.90f));
                }
            }

        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if(health <= 0)
        {
            Die();
        }
    }

    public void FixedUpdate()
    {

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        // "Friction", easing the x speed of the player
        if(grounded)
        {
            rb2d.velocity = easeVelocity;
        }
  
        float h = Input.GetAxis("Horizontal");
        
        // Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        // Limiting the speed of the player
        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    public void ChangeInvincibility()
    {
        invincible = !invincible;
    }

	public void SetHurtTrue(){
		anim.SetBool("Hurt", true);
	}
	
	public void SetHurtFalse(){
		anim.SetBool("Hurt", false);
	}
	
    public void Damage(int dmg)
    {
        if (!invincible)
        {
			SetHurtTrue();
            ChangeInvincibility();
            health -= dmg;
            anim.Play("Player_flash", -1, 0f);
        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Coin"))
		{
			Destroy(col.gameObject);
			gm.coins += 1;
		}
		
		if(col.CompareTag("Heart"))
		{
			Destroy(col.gameObject);
			health += 1;
		}
	}
	
    public void Die()
    {
        // Restarts the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}

