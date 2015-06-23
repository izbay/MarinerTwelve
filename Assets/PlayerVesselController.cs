using UnityEngine;
using System.Collections;

public class PlayerVesselController : MonoBehaviour {
	public float speed = 30.0f;
	public float throttle = 0f;
	public float RotationSpeed = 20f;
	public float throttleTick = 1f;

	CharacterController controller;
	Rigidbody rb;

	void Start () {
		controller = transform.GetComponent<CharacterController>();
		rb = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {

		Control();
		Move();
	}

	void Control(){
		Rotate();
		Throttle();
	}

	void Throttle(){
		if(Input.GetKey(KeyCode.LeftShift)){throttle += throttleTick;}
		if(Input.GetKey(KeyCode.LeftControl)){throttle -= throttleTick;}
		if(throttle < 0f) throttle = 0f;
		if(throttle > speed) throttle = speed;
	}

	void Rotate(){
		Quaternion AddRot = Quaternion.identity;
		float roll = 0;
		float pitch = 0;
		float yaw = 0;
		
		roll = Input.GetAxis("Roll") * (Time.deltaTime * RotationSpeed) * 2f;
		pitch = Input.GetAxis("Vertical") * (Time.deltaTime * RotationSpeed);
		yaw = Input.GetAxis("Horizontal") * (Time.deltaTime * RotationSpeed) * 0.25f;

		AddRot.eulerAngles = new Vector3(pitch, yaw, -roll);
		rb.rotation *= AddRot;
	}

	void Move(){
		transform.Translate(Vector3.forward * throttle * Time.deltaTime);
	}
}
