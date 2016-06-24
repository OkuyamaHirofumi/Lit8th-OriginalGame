using UnityEngine;
using System.Collections;

public class PowerUpItem : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Destroy (this.gameObject);
			PowerUpText put = GameObject.Find ("PowerUpText").GetComponent<PowerUpText> ();
			put.ShowText ("パワーアップ！！");
		}
	}
}
