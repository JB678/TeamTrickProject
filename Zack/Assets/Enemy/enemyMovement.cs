using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
	public Transform player; //Used to calculate distance between enemy and player
	public LayerMask playerLayer; //Used to determine if enemy is facing player
	
	Vector2 direction = new Vector2(1, 0);
    float speed = 3f; //Enemy movement speed
    Rigidbody2D rb;
	int sightRange = 10; //From how far enemy can detect player
	Vector3 startingPosition;
	//float xScale = Mathf.Abs(transform.localScale.x);
	
    void Start() {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
		startingPosition = transform.position;
	}
	
    void Update() { //Update makes the enemy constantly scan for player
		Debug.DrawRay(transform.position, direction, Color.green);
		RaycastHit2D playerDetector = Physics2D.Raycast(transform.position, direction, sightRange, playerLayer); //Detects if player in front of enemy
		rb.velocity = new Vector3(speed, rb.velocity.y, 0); //Enemy constantly moves forward
		
		if (Vector3.Distance(transform.position, player.position) <= sightRange) { //Enemy will chase after player within a certain distance
			if(!playerDetector) { turnAround(); } //Turn enemy around if not facing player
		}

	}//End Update
	
	void OnTriggerExit2D(Collider2D other) { //Keeps enemy in patrol range
		if (other.tag == "patrolRange") {
			//Debug.Log("Exited");
			turnAround();
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag=="playerBullet") {
			Destroy(other.gameObject);
		}
		else { turnAround(); }
	}
	
	void turnAround() { //Enemy goes other way
		Vector3 scale = transform.localScale; //Get direction enemy faces
		scale.x = -scale.x; //Change direction
		transform.localScale = scale; //Apply changed direction to enemy
		direction *=new Vector2(-1, 0); //Change direction of ray
		speed*=-1; //Makes speed opposite
	}//End turnAround
}
