using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.InitiateGame += PlayAnimation;
	}
	
    void PlayAnimation()
    {
        GetComponent<Animator>().Play("Disappear");
    }
    // Update is called once per frame
    void Update () {
		
	}
    void OnDisable()
    {
        GameManager.InitiateGame -= PlayAnimation;
    }
}
