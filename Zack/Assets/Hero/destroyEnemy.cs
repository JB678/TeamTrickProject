using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour {
	GameObject thisBullet;
    // Start is called before the first frame update
    void Start() {
        thisBullet = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        
    }
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag=="Enemy") {
			Destroy(other.gameObject);
			Destroy(thisBullet);
		}
	}
}
