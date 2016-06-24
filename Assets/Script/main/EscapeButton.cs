using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EscapeButton : MonoBehaviour
{
	public Button rightButton;
	public Button leftButton;
	// Use this for initialization
	void Awake ()
	{
		GetComponent<Button> ().interactable = false;
	}

	void Start ()
	{

	}
	// Update is called once per frame
	void Update ()
	{
		SetInteractive ();
	}

	void SetInteractive ()
	{
		Button btn = gameObject.GetComponent<Button> ();
		if (player.charge > 0) {
			btn.interactable = true;
		} else {
			btn.interactable = false;
		}
	}

	public void PushEscape ()
	{
		player.escapeFlag = true;
		GameObject.Find ("CountDown").GetComponent<Text> ().text = "";

		/*各ボタンのアクティブ切り替え*/
		gameObject.SetActive (false);
		rightButton.gameObject.SetActive (true);
		leftButton.gameObject.SetActive (true);
	}
}
