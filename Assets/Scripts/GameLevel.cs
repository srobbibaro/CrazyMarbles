using UnityEngine;
using System.Collections;

public class GameLevel : MonoBehaviour {

	public GameObject coin;
	
	public long score = 0;
	public static long highScore = 0;
	
	public bool isGameStarted = false;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}
	
	public void incScore(long incAmount) {
		score += incAmount;
	}
	
	public void resetScore() {
		if (highScore < score) {
			highScore = score;
		}
		
		score = 0;
	}
	
	void OnGUI () {
		if (!isGameStarted) {
    		GUI.Label (new Rect ((Screen.width - 100) / 2, 10, 800, 20), "- Crazy Marbles -");
    		GUI.Label (new Rect ((Screen.width - 100) / 2, 50, 800, 20), "Control the red marble by moving the mouse. Press 'Q' to quit.");
    		GUI.Label (new Rect ((Screen.width - 100) / 2, 90, 800, 20), "Collect as many coins as you can before falling from the platform!");
    		GUI.Label (new Rect ((Screen.width - 100) / 2, 130, 200, 20), "High Score: " + highScore.ToString());
			if (GUI.Button(new Rect ((Screen.width - 100) / 2, (Screen.height - 20) / 2, 100, 20),"Start Game!")) {
				isGameStarted = true;
				Screen.showCursor = false;
				addNewCoin();
			}
		}
		else {
    		GUI.Label (new Rect (10, 10, 500, 20), "Score: " + score.ToString() + " High Score: " + highScore);
		}
	}
	
	public void addNewCoin() {
	  	Vector3 position = new Vector3(Random.Range(-15.0f, 15.0f), 2.0f, Random.Range(-15.0f, 15.0f));
		GameObject newCoin = (GameObject)Instantiate(coin, position, Quaternion.identity);
		newCoin.rigidbody.AddTorque(new Vector3(0.0f, 60.0f, 0.0f));
	}
}
