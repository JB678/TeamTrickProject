using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    Rigidbody2D rb2D;
	private float bulletSpeed;
	public Vector2 dir;
	
	// Start is called before the first frame update
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
		bulletSpeed = 15f;
    }

    // Update is called once per frame
    void Update() {
        rb2D.AddForce(dir*bulletSpeed);
    }
}
