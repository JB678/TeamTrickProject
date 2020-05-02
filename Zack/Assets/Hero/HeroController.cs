using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
    public Sprite crouchSprite;
	public Animator anim;

    float speed = 5f;
	Rigidbody2D rb;
	SpriteRenderer sr;
	int shootTimer = 0;
	public LayerMask groundLayer;
	public GameObject leftBullet;
	public GameObject rightBullet;
	
    void Start() {
        rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
    }
        
	void Update() {
		
		var horizontalMove = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
		var movement = horizontalMove * speed;

		rb.velocity = new Vector3(movement, rb.velocity.y, 0);
		if (horizontalMove !=0) { anim.SetBool("runKey", true); }
		else { anim.SetBool("runKey", false); }
		if (horizontalMove < 0.0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalMove > 0.0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
		
		//Press W to make Player jump - only if on ground.
		float xScale = Mathf.Abs(transform.localScale.x);
		
		if (Input.GetKeyDown(KeyCode.W)) {
			if (IsGrounded()) {
				rb.AddForce(new Vector3(0, 400, 0));
				anim.SetTrigger("jumpKey");
			}else {}
		}
		
		shootTimer--;
		if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0) {
			if(horizontalMove >= 0.0) { Destroy(Instantiate(rightBullet, (transform.position + new Vector3(2, 0, 0)), transform.rotation), 1.5f); }
			else if(horizontalMove < 0.0) { Destroy(Instantiate(leftBullet, (transform.position - new Vector3(2, 0, 0)), transform.rotation), 1.5f); }
			shootTimer = 50;
		}
	}//End Update
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag=="Bullet") {
			MasterController.reduceHP(30);
		}
		if (other.tag=="exit") {
			MasterController.endGame();
		}
	}
	
	
	bool IsGrounded() { //Returns true if player is on ground
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.5f;
    
		Debug.DrawRay(position, direction*1, Color.green);
		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
		if (hit.collider != null) { return true; }
		return false;
	}//End isGrounded
	
	
}//End of Script
