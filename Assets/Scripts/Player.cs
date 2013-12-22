using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Color playerColor = Color.red;

	public Vector3 thrust;
	
	public float force = 5.0f;
	
	// Use this for initialization
	void Start () {
		renderer.material.color = playerColor;
		thrust.Set(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gameLevel = GameObject.Find("GameLevel");
        GameLevel gameLevelScript = gameLevel.GetComponent<GameLevel>();
        
		if (gameLevelScript.isGameStarted) {	
	 		// Get the mouse delta. This is not in the range -1...1
    		thrust.x = force * Input.GetAxis ("Mouse X");
    		thrust.z = force * Input.GetAxis ("Mouse Y");
    	
			rigidbody.AddForce(thrust);
			
			if (transform.position.y < -10.0f || Input.GetKeyDown(KeyCode.Q)) {
				gameLevelScript.resetScore();
				Application.LoadLevel("Level1");
				Screen.showCursor = true;
			}
		}
	}
	
	void OnCollisionEnter(Collision collision) {
    }
}
