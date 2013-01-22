using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void die(){
		Destroy(gameObject);
		GameObject paddleObject = GameObject.Find("Paddle");
		PaddleScript paddleScriptt = paddleObject.GetComponent<PaddleScript>();
		paddleScriptt.spawnBall();
	}
	
}
