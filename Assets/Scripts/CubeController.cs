using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    public int hitPoints;
    public GameObject particleEffect;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Make the cube rotate over time (frame-independent)
        transform.Rotate(new Vector3(45, 30, 15) *Time.deltaTime);
	}
    private void OnTriggerEnter()
    {
        /* -Update Score
        -Instantiate particleEffect System
        -Destroy particleEffect
        -destroy gameObject */

        GameObject.Find("GameController").GetComponent<ScoreManager>().UpdateScore(hitPoints, gameObject.GetComponent<Renderer>().material.color );
        GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity);
        Destroy(particle, 1.0f);
        Destroy(gameObject);
    }
}
