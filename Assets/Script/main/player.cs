using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour
{
	/*スワイプで使用する位置と時間*/
	public float StartPos, EndPos;
	public float StartTime, EndTime;
	/*スワイプによるチャージされた量*/
	public static float charge = 0;
	public static float bgSpeed = 1.0f;
	public float playerSpeed = 2.0f;
	public float decreaseSpeed = 3.0f;
	/*各種フラグ*/
	public static bool escapeFlag = false;
	public static bool moveRightFlag, moveLeftFlag = false;
	public GameObject background, ButtonController;
	public Text countText, chargeText, ScoreText;
	string offset = "";
	float highScore = 0;
	float countDown = 10.0f;
	public static float height = 0;
	//記録となる高さ
	const string HIGH_SCORE_KEY = "highScore";
	Animator animator;
	// Use this for initialization
	void Start ()
	{
		/*ハイスコア乗りセット*/
//		PlayerPrefs.SetFloat (HIGH_SCORE_KEY, 0.0f);


		offset = "";
		animator = GetComponent<Animator> ();
		ScoreText.text = "";
		charge = 0.0f;
		height = 0.0f;
		escapeFlag = false;
		moveLeftFlag = false;
		moveRightFlag = false;
		ButtonController.gameObject.SendMessage ("StartStateButtons");
	}
	// Update is called once per frame
	void Update ()
	{	
		CountDown ();
		Swipe ();
		if (escapeFlag) {
			Escape ();

		}
	
		showCharge (charge.ToString ());

		if (charge >= 0) {
			Move ();
		} else {
			/*ゲームオーバー*/
			GameOver ();
		}
	}
	/*スワイプでチャージ*/
	void Swipe ()
	{
		float interval = 0;
		float distance = 0;
		if (Input.GetMouseButtonDown (0)) {
			StartPos = Input.mousePosition.x;
			StartTime = Time.time;
		}
		if (Input.GetMouseButtonUp (0)) {
			EndPos = Input.mousePosition.x;
			EndTime = Time.time;
			distance = EndPos - StartPos;
			interval = EndTime - StartTime;
			//Debug.Log ("sp: " + StartPos + " , end : "+ EndPos);
//			Debug.Log ("distance : " + distance + " interval : " + interval);
			if (distance > 0) {
				/*スワイプされたときの動作*/
				Charge (distance, interval);
			} 
		}
	}

	void Charge (float distance, float interval)
	{
		charge += (distance * 0.1f) / (interval * 10f);

	}
	/*脱出後*/
	void Escape ()
	{
		if (charge > 0) {
			/*背景スクロール*/
			background.transform.position += Vector3.down * bgSpeed * Time.deltaTime;
			/*チャージ量を減少させていく*/
			charge -= Time.deltaTime * decreaseSpeed;
			height += Time.deltaTime * decreaseSpeed;
		} else {

			transform.position += Vector3.down * Time.deltaTime * 5.0f;
		}
	
	}

	void CountDown ()
	{	
		if (escapeFlag) {
			countText.text = "";
		} else {
			if (countDown > -0.5) {
				countDown -= Time.deltaTime;
				countText.text = ((int)Mathf.Ceil (countDown)).ToString ();
			} else {
				countText.text = "";
				/*カウントが0になったときに脱出してなかったらゲームオーバー*/
				if (!escapeFlag) {
					GameOver ();
				}
			}
		}
	}
	/*ボタンでの移動*/
	void Move ()
	{
		Vector3 distance = new Vector3 (0, 0, 0);
		Camera camera = Camera.main;
		Vector3 min = camera.ViewportToWorldPoint (new Vector3 (0, 0, camera.nearClipPlane));
		Vector3 max = camera.ViewportToWorldPoint (new Vector3 (1, 1, camera.nearClipPlane));
		Vector3 pos = transform.position;
		if (moveRightFlag) {
			distance = Vector3.right * playerSpeed * Time.deltaTime;
		}
		if (moveLeftFlag) {
			distance = Vector3.left * playerSpeed * Time.deltaTime;
		}


		pos += distance;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);


		transform.position = pos;

	}
	/*ハイスコアの初期化*/
	public void InitScore ()
	{
		highScore = 0;
		PlayerPrefs.SetFloat (HIGH_SCORE_KEY, highScore);
	}
	/*ハイスコアのセーブ*/
	public void SaveHighScore (float score)
	{	
		if (!PlayerPrefs.HasKey (HIGH_SCORE_KEY)) {
			InitScore ();
		}
		highScore = LoadHighScore ();
		if (score > highScore) {
			highScore = score;
		}
		PlayerPrefs.SetFloat (HIGH_SCORE_KEY, highScore);
		PlayerPrefs.Save ();
	}
	/*ハイスコアのロード*/
	public static float LoadHighScore ()
	{
	
		return PlayerPrefs.GetFloat (HIGH_SCORE_KEY, 0);
		
	}
	/*ゲームオーバー処理*/
	public void GameOver ()
	{
		//スコアの表示
		if (height > LoadHighScore ()) {
			offset = "ハイスコア！！\n";
		}
		ScoreText.text = offset + "脱出した高さ " + ((int)height).ToString ("f1") + "M";
		//ハイスコアの記録
		SaveHighScore (height);
		//ボタンの表示・非表示
		ButtonController.gameObject.SendMessage ("GameOverStateButtons");

	}
	/*障害物やパワーップアイテムに接触したとき*/
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "obstacle") {
			animator.SetBool ("DAMAGE", true);
			charge -= 5.0f;
			Invoke ("StopDamage", 1.5f);
			debug ("衝突");
		}
		if (other.tag == "obstacle") {

		}
		if (other.tag == "obstacle") {

		}
		if (other.tag == "obstacle") {

		}

	}

	void StopDamage ()
	{
		animator.SetBool ("DAMAGE", false);
	}
	/*ボタンの検知*/
	public void PushRightDown ()
	{
		moveRightFlag = true;
	}

	public void PushRightUp ()
	{
		moveRightFlag = false;
	}

	public void PushLeftDown ()
	{
		moveLeftFlag = true;
	}

	public void PushLeftUp ()
	{
		moveLeftFlag = false;
	}
	/*テスト用*/
	void debug (string s)
	{
		Debug.Log (s);
	}

	void showCharge (string s)
	{
		chargeText.text = s;
	}
}
