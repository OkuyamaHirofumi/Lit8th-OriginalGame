using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {
	public Text hsText;

	// Use this for initialization
	void Start () {
		hsText.text = "ハイスコア : " + player.LoadHighScore().ToString("f1") + " M";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
