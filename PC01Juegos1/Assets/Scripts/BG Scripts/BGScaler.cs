using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	private float height;
	private float width;

	// Use this for initialization
	void Start () {
		height = Camera.main.orthographicSize * 2f; //cuenta desde el centro hacia abajo y hacia arriba
		width = height * Screen.width / Screen.height;
		if (gameObject.name == "BGQuad") {
			gameObject.transform.localScale = new Vector2 (width, height);
		} else {
			gameObject.transform.localScale = new Vector2 (width, height);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
