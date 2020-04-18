using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	[Header("Movement Variables")]
	public float playerSpeedMovement;
	private float vertical;

	[Header("Position Variables")]
	public float minPosY;
	public float maxPosY;
	private float currentPosY;

	[Header("Other Variables")]
	private Rigidbody2D rbPlayer;

	[Header("Lives Variables")]
	public int playerLives;

	[Header("UI Variables")]
	public Text txtLives;

	// Use this for initialization
	void Start () {
		GetInitialComponent ();
	}
	
	// Update is called once per frame
	void Update () {
		currentPosY = Mathf.Clamp(transform.position.y, minPosY, maxPosY);
		rbPlayer.position = new Vector2 (rbPlayer.position.x, currentPosY);
	}

	void FixedUpdate () {
		vertical = Input.GetAxisRaw ("Vertical");
		rbPlayer.velocity = new Vector2 (rbPlayer.velocity.x, playerSpeedMovement * vertical);
	}

	void GetInitialComponent () {
		rbPlayer = GetComponent<Rigidbody2D> ();
		txtLives.text = "LIVES: " + playerLives.ToString ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Candy") {
			CandyControl candy;
			candy = other.GetComponent<CandyControl> ();
			switch (candy.candyType) {
			case 1:
				playerLives = playerLives - 3;
				break;
			case 2:
				playerLives = playerLives + 2;
				break;
			case 3:
				playerLives = 0;
				break;
			case 4:
				playerLives = playerLives - 1;
				break;
			default:
				playerLives = playerLives - 1;
				break;
			}
			txtLives.text = "LIVES: " + playerLives.ToString ();
			candy.ReturnToDeactivate ();
			print ("La cantidad de vidas es de: " + playerLives);
			if (playerLives <= 0) {
				SceneManager.LoadScene ("GameOver");
			}
		}
	}
}
