using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttackScript : MonoBehaviour {
	public Animator anim;
	public Transform player;
	Rigidbody2D rb;
	int timer = 0;
	
	double attackRange = 1.5;
	
    void Start() {
        anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
		timer--;
        if(Vector3.Distance(transform.position, player.position) <= attackRange) {
			if(timer<=0) { 
				anim.SetTrigger("meleeAttack");
				MasterController.reduceHP(10);
				timer = 30;
			}
		}
    }
}
