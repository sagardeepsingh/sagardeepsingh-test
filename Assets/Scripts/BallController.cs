using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed;
    Rigidbody rb;
    public bool gameStarted = false;
	// Use this for initialization
	void Start () {
        //Initialize Components
       rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //Move the ball if the game has started.

        if (gameStarted == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = move * speed;
        }
	}
}
