using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCandiesContainerControl : MonoBehaviour {

	[Header("Candy Pref Variables")]
	public GameObject candyPref;

	[Header("Candy Sprites Variables")]
	public List<Sprite> allPosibleSprites;

	[Header("Candy Position Variables")]
	public Vector2 posToCreateCandy;

	[Header("Candy Time Variables")]
	public float timeToActivateCandy;

	[Header("Candy Lists Variables")]
	public int initialCandiesCount;
	public List<CandyControl> allCandiesList;
	public List<CandyControl> allDeactivateCandiesList;

	// Use this for initialization
	void Start () {
		GenerateAllCandies ();
		Invoke ("ActivateCandies", timeToActivateCandy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateAllCandies(){
		GameObject prefTmp;
		CandyControl candyTmp;
		int currentCandy = 0;
		for (int i = 0; i < initialCandiesCount; ++i) {
			prefTmp = Instantiate (candyPref, posToCreateCandy, transform.rotation);
			prefTmp.transform.SetParent (this.transform);
			candyTmp = prefTmp.GetComponent<CandyControl> ();
			candyTmp.SetInitialValues (allPosibleSprites [currentCandy], currentCandy, GetComponent<AllCandiesContainerControl>());
			currentCandy = currentCandy + 1;
			if (currentCandy >= allPosibleSprites.Count) {
				currentCandy = 0;
			}
			//allCandiesList.Add (candyTmp);
			allDeactivateCandiesList.Add (candyTmp);
			prefTmp.gameObject.SetActive (false);
		}

		//allDeactivateCandiesList = allCandiesList;
	}

	void ActivateCandies(){
		CandyControl tmp;
		int index = Random.Range (0, allDeactivateCandiesList.Count);
		tmp = allDeactivateCandiesList [index];
		tmp.gameObject.SetActive (true);
		tmp.StartMovement ();
		allDeactivateCandiesList.RemoveAt (index);
		allCandiesList.Add (tmp);
		Invoke ("ActivateCandies", timeToActivateCandy);
	}

	public void ReturnToDeactivate(CandyControl candy){
		CandyControl tmp = candy;
		candy.gameObject.SetActive (false);
		allCandiesList.Remove (candy);
		allDeactivateCandiesList.Add (tmp);
	}
}
