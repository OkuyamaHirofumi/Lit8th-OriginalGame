using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update ()
	{
		gameObject.SetActive (true);
	}

	public void PushRetry ()
	{
		SceneManager.LoadScene ("main");
	}
}
