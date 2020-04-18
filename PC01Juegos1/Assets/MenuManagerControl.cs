using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerControl : MonoBehaviour {

	[Header("Button Variables")]
	public Button btnPlayButton;
	public Button btnAbout;

	// Use this for initialization
	void Start () {
		btnPlayButton.onClick.AddListener(() => LoadGame());
		btnAbout.onClick.AddListener(() => LoadAbout());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadGame(){
		SceneManager.LoadScene ("Game");
	}

	void LoadAbout(){
		SceneManager.LoadScene ("About");
	}
}
