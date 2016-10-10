using UnityEngine;
using System.Collections;

public class BallFollower : MonoBehaviour {

	public GameObject player;
		
	// Use this for initialization
	void Start () {
		transform.position = player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = player.transform.position;

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.RotateAround (transform.position,transform.up,Time.deltaTime * 90f);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.RotateAround (transform.position,transform.up,Time.deltaTime * -90f);
		}
	}
}
