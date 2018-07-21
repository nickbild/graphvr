using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {

	public GameObject user;
	
	void FixedUpdate () {

		if (Input.GetKey(KeyCode.A)) { // up
			//user.transform.Translate(Vector3.down * 5.0f * Time.deltaTime, Space.World);
			user.transform.Translate(Vector3.back * 5.0f * Time.deltaTime, Space.Self);

		} else if (Input.GetKey(KeyCode.Q)) { // down
			//user.transform.Translate(Vector3.up * 5.0f * Time.deltaTime, Space.World);
			user.transform.Translate(Vector3.forward * 5.0f * Time.deltaTime, Space.Self);

		}

		if (Input.GetKey(KeyCode.S)) { // back
			user.transform.Translate(Vector3.down * 5.0f * Time.deltaTime, Space.World);

		} else if (Input.GetKey(KeyCode.W)) { // forward
			user.transform.Translate(Vector3.up * 5.0f * Time.deltaTime, Space.World);

		}

		if (Input.GetKey(KeyCode.UpArrow)) { // rotate up
			user.transform.Rotate(Vector3.right, 40.0f * Time.deltaTime);

		} else if (Input.GetKey(KeyCode.DownArrow)) { // rotate down
			user.transform.Rotate(Vector3.left, 40.0f * Time.deltaTime);

		}

		if (Input.GetKey(KeyCode.LeftArrow)) { // rotate left
			user.transform.Rotate(Vector3.down, 40.0f * Time.deltaTime);

		} else if (Input.GetKey(KeyCode.RightArrow)) { // rotate right
			user.transform.Rotate(Vector3.up, 40.0f * Time.deltaTime);
			
		}

	}
}

