using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	
	public GameObject ball;
	GameObject attachedBall = null;
	GUIText lives = null; 
	int noOfLives =4;
	public void spawnBall ()
	{
		if(ball == null){
			Debug.Log("Failed to initialize the ball");
			return;
		}
		lives.text = "Lives : "+noOfLives; 
		noOfLives--;
		Vector3 ballPosition = transform.position + new Vector3(0,.75f,0);
		Quaternion ballRotation = Quaternion.identity;
		attachedBall = (GameObject)Instantiate(ball,ballPosition,ballRotation);
		
	}
	
	// Use this for initialization
	void Start () {
		lives = GameObject.Find("lives").GetComponent<GUIText>();
		spawnBall ();	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(10f * Input.GetAxis("Horizontal")* Time.deltaTime,0,0);
		if(attachedBall){
			Rigidbody attachedBallRigidBody = attachedBall.rigidbody;
			attachedBallRigidBody.position = transform.position + new Vector3(0,0.75f,0);
			if(Input.GetButtonDown("Jump")){
				attachedBallRigidBody.isKinematic = false;
				attachedBallRigidBody.AddForce(200 *Input.GetAxis("Horizontal") ,300,0);
				attachedBall = null;
			}
		}
		
	}
	
	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contactPoint in collision.contacts)  {
			if(contactPoint.thisCollider == collider ){
				float offset = contactPoint.point.x - collider.transform.position.x;
				contactPoint.otherCollider.rigidbody.AddForce(300f * offset,0,0);
			}
		}
	}
	
}
