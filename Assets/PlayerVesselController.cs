using UnityEngine;
using System.Collections;

public class PlayerVesselController : MonoBehaviour {
	public float speed = 30.0f;
	public float throttle = 10f;
	CharacterController controller;

	void Start () {
		controller = transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift)){
			throttle += 0.5f;
		}

		if(Input.GetKey(KeyCode.LeftControl)){
			throttle -= 0.5f;
		}

		if(throttle < 0f) throttle = 0f;
		if(throttle > speed) throttle = speed;

		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
		                        Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= throttle;

		controller.Move(moveDirection * Time.deltaTime);
	}
}
