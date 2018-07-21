using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject user;

    private Vector3 offset;

    void Start ()
    {
        //offset = transform.position - user.transform.position;
    }
    
    void LateUpdate ()
    {
        //transform.position = user.transform.position + offset;
	//transform.rotation = user.transform.rotation;
    }
}
