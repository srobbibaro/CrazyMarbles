using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    // Use this for initialization
    void Start () {}
    
    // Update is called once per frame
    void Update () {}
    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == GameObject.Find("MarblePlayer")) {
            GameObject gameLevel = GameObject.Find("GameLevel");
            
            if (gameLevel != null) {
                GameLevel gameLevelScript = gameLevel.GetComponent<GameLevel>();
                gameLevelScript.incScore(1000);
                Destroy(gameObject);
                gameLevelScript.addNewCoin();
            }
            else {
                Debug.Log("GameLevel was null in Coin:OnCollisionEnter");
            }
        }
    }
}
