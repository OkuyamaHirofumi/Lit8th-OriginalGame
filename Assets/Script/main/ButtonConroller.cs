using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonConroller : MonoBehaviour {
	public Button right,left,escape,retry;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void GameOverStateButtons(){
		right.gameObject.SetActive (false);
		left.gameObject.SetActive (false);
		escape.gameObject.SetActive (false);
		retry.gameObject.SetActive (true);
	
	}
	void StartStateButtons(){
		right.gameObject.SetActive (false);
		left.gameObject.SetActive (false);
		retry.gameObject.SetActive (false);
		escape.gameObject.SetActive (true);
	}


}
