using UnityEngine;
using System.Collections;

public class EnemyMarble : MonoBehaviour {

    public float size = 2.0f;
    public float force = 50.0f;
    public Color playerColor = Color.green;
    
    private Vector3 thrust;

    // Use this for initialization
    void Start () {
        Vector3 scale = new Vector3(size, size, size);
        transform.localScale = scale;
        rigidbody.mass = size * 5.0f;
        
        thrust.Set(0.0f, 0.0f, 0.0f);
        
        renderer.material.color = playerColor;
    }
    
    // Update is called once per frame
    void Update () {
        GameObject gameLevel = GameObject.Find("GameLevel");
        
        if (gameLevel == null) {
            Debug.Log("GameLevel was null in EnemyMarble:Update()");
            return;
        }
            
        GameLevel gameLevelScript = gameLevel.GetComponent<GameLevel>();
        
        if (gameLevelScript.isGameStarted) {    
            GameObject player = GameObject.Find("MarblePlayer");
            
            if (player == null) {
                Debug.Log("Player was null in EnemyMarble:Update()");
                return;
            }
            
            Vector3 playerPosition = player.transform.position;

            thrust.x = 0;
            if (playerPosition.x > transform.position.x) {
                thrust.x = force;
            }
            else if (playerPosition.x < transform.position.x) {
                thrust.x = -force;
            }
    
            thrust.z = 0;
            if (playerPosition.z > transform.position.z) {
                thrust.z = force;
            }
            else if (playerPosition.z < transform.position.z) {
                thrust.z = -force;
            }
        
            rigidbody.AddForce(thrust);
        
            if (transform.position.y < -10.0f) {
                  Vector3 position = new Vector3(Random.Range(-15.0f, 15.0f), 10.0f, Random.Range(-15.0f, 15.0f));
                  transform.position = position;
            }
        }
    }
}
