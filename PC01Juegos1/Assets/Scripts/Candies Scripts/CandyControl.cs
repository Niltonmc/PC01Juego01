using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyControl : MonoBehaviour {

	[Header("Other Variables")]
	private SpriteRenderer spriteRend;
	private Rigidbody2D rbCandy;

	[Header("Candy Type Variables")]
	public int candyType;

	[Header("Candy Speed  Variables")]
	public float candySpeed;

	[Header("Candy Position Variables")]
	public int minPosY;
	public int maxPosY;

	[Header("Candy Container Variables")]
	private AllCandiesContainerControl allCandiesContainer;

	void Awake () {
		rbCandy = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		rbCandy.velocity = new Vector2 (candySpeed, rbCandy.velocity.y);
	}

	public void SetInitialValues(Sprite spr, int val, AllCandiesContainerControl father){
		spriteRend = GetComponent<SpriteRenderer> ();
		spriteRend.sprite = spr;
		candyType = val;
		allCandiesContainer = father;
	}

	public void StartMovement(){
		float posY = Random.Range (minPosY, maxPosY);
		rbCandy.position = new Vector2 (rbCandy.position.x, posY);
	}

	public void ReturnToDeactivate(){
		allCandiesContainer.ReturnToDeactivate (GetComponent<CandyControl> ());
	}
}
