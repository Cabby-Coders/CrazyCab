using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreByVelocity : MonoBehaviour {

    private Rigidbody rb;
    public int score;
    [SerializeField] private Config config;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        score = 0;
		
	}

    public int GetScore() {
        return score;
    }

    float GetVelocity () {
        return rb.velocity.magnitude;
    }
	
	// Update is called once sper frame
	void FixedUpdate () {
       
        score += (int) GetVelocity();
        Debug.Log(score);
        config.scoreText.text = GetScore().ToString();
	}

    [System.Serializable]
    public class Config
    {
        public Text scoreText;
    }
}
