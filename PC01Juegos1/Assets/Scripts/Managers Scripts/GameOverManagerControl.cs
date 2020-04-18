using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManagerControl : MonoBehaviour {

	[Header("Button Variables")]
	public Button btnPlayButton;

	// Use this for initialization
	void Start () {
		btnPlayButton.onClick.AddListener(() => LoadMenu());
	}

	// Update is called once per frame
	void Update () {

	}

	void LoadMenu(){
		SceneManager.LoadScene ("Menu");
	}
		
}
