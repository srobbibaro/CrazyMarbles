using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("MarblePlayer");
		if (player != null) {
			Vector3 playerPosition = player.transform.position;
			playerPosition += new Vector3(0.0f, 10.0f, -20.0f);
			transform.position = playerPosition;
		}
		else {
			Debug.Log ("Player was null in MainCamera:Update");
		}
	}
}
