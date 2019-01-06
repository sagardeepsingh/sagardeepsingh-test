using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject ball;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        //calculate offset
        offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //lerp movement with the ball
        transform.position = Vector3.Lerp(transform.position, ball.transform.position + offset, 1);	
	}
}
