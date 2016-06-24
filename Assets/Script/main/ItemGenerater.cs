using UnityEngine;
using System.Collections;

public class ItemGenerater : MonoBehaviour {
	Camera camera;
	Vector3 min;
	Vector3 max;
	public GameObject[] Item;
	int ItemID;
	float timer = 0;
	int waitingTime = 1;
	// Use this for initialization
	void Start () {
		camera = Camera.main;
		min = camera.ViewportToWorldPoint (new Vector3 (0, 0, camera.nearClipPlane));
		max = camera.ViewportToWorldPoint (new Vector3 (1, 1, camera.nearClipPlane));
		transform.position = max + Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > waitingTime) {
			if (player.escapeFlag && player.charge > 0) {
				Generate ();
			}
			timer = 0;
		}
	}

	void Generate ()
	{

		transform.position = new Vector3(Random.Range (min.x, max.x), transform.position.y,0);
		Instantiate (Item[0], transform.position, transform.rotation);
	}
}
