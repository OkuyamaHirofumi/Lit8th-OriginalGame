using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpText : MonoBehaviour {
	public  Text pwText;
	public   GameObject player;
	 Camera mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		pwText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowText(string s){

		Vector3 pos = mainCamera.WorldToScreenPoint (player.transform.position);
		Debug.Log (pos);
		pwText.text = s;
		pwText.rectTransform.position = RectTransformUtility.WorldToScreenPoint(mainCamera,player.transform.position + Vector3.up );
		Invoke ("DeleteText", 1.0f);
	}

	public void DeleteText(){
		pwText.text = "";
	}
}
