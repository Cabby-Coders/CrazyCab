using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreByVelocity : MonoBehaviour {

    private Rigidbody rb;
    public int score;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        score = 0;
		
	}

    float GetVelocity () {
        return rb.velocity.magnitude;
    }
	
	// Update is called once sper frame
	void FixedUpdate () {
       
        score += (int) GetVelocity();
        Debug.Log(score);

	}
}
