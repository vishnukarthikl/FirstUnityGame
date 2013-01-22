using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
			transform.Translate(10 * Input.GetAxis("Horizontal")* Time.deltaTime,0,0);
		
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
