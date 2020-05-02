using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
	public Transform player;
	Transform tf;
	
	void Start() {
		tf = GetComponent<Transform>();
	}
	
    // Update is called once per frame
    void Update() {
        tf.position = new Vector3(player.position.x, 0, -7);
    }
}
