using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterController : MonoBehaviour {
	public GameObject player;
	public Text healthText;
	static int playerHP;
	Vector3 startingPosition;
	Transform tf;
	
    void Start() {
		tf = GetComponent<Transform>();
		startingPosition = player.transform.position;
        playerHP = 100;
    }

    void Update() {
		tf.position = new Vector3(player.transform.position.x, 0, -7);
		healthText.text = "Health: " + playerHP;
    }
	
	public static void reduceHP(int hit) {
		playerHP-=hit;
		if (playerHP<=0) { SceneManager.LoadScene("SampleScene"); }
	}
	
	public static void endGame() {
		SceneManager.LoadScene("EndGameScreen");
	}
}
