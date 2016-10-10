using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text text;

	void Start ()
	{
		count = 0;
		text.text = ""+count;
		rb = GetComponent <Rigidbody>();
	}

	void FixedUpdate ()
	{
		Vector3 movement = GameObject.Find ("Main Camera").transform.forward;



		movements (speed,movement);
		boost(speed,movement);
		rb.AddForce (movement * 0.01f);
	}

	void movements(float speed, Vector3 movement){
		

		if(Input.GetKey (KeyCode.UpArrow)){
			rb.AddForce (movement * speed);

		}
		else if(Input.GetKey (KeyCode.DownArrow)){
			rb.AddForce (new Vector3(0f,0f,-GameObject.Find ("Main Camera").transform.forward.z) * speed);
			print (movement); 
		}

		if(Input.GetKeyDown (KeyCode.Space) && !Input.GetKey (KeyCode.LeftShift)){
			movement = new Vector3(0f,0f,0f);
			movement = new Vector3(0f,10f,0f);
			rb.AddForce (movement * speed);
		}


	}

	void boost (float speed, Vector3 movement)
	{
		if(Input.GetKeyDown (KeyCode.LeftShift)){
			this.speed = 50;

			if(Input.GetKeyDown (KeyCode.Space)){
			rb.AddForce (movement * 10f);
		}
		}
		else if(Input.GetKeyUp (KeyCode.LeftShift)){
			this.speed = 10;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag ("Pick Up")){
			
			other.gameObject.SetActive (false);
			text.text = ""+ ++count;
		}
	}
}
