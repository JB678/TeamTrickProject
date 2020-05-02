using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttack : MonoBehaviour {
    
	public Transform player;
	Rigidbody2D rb;
	int attackRange = 10;
	int timer = 0;
	public GameObject leftBullet;
	public GameObject rightBullet;
	
    void Start() { rb = GetComponent<Rigidbody2D>(); }

    void Update() {
		timer--;
		if(Vector3.Distance(transform.position, player.position) <= attackRange) {
			if(timer<=0) {
				if(rb.velocity.x > 0.0) { Destroy(Instantiate(rightBullet, (transform.position + new Vector3(2, 0, 0)), transform.rotation), 2f); }
				else { Destroy( Instantiate(leftBullet, (transform.position - new Vector3(2, 0, 0)), transform.rotation), 2f); }
				timer = 100;
			}
		}
    }
}
