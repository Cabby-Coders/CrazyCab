﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab {
  public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private Config config;

    private float currentSpeed;
    public Rigidbody rb;

    public void Start (){
      rb = GetComponent<Rigidbody>();
      rb.velocity = new Vector3(0, 0, config.startingSpeed);
      currentSpeed = config.startingSpeed;
    }

		public void FixedUpdate() {
      Accelerate();
      GoForward();
      Steer();
    }
	
	private void OnCollisionEnter(Collision collision)
	{

      rb.velocity = new Vector3(0, 0, -1 * config.startingSpeed);
	}

  private void Accelerate() {
    currentSpeed += config.acceleration;
  }

  private void GoForward() {
    rb.velocity = transform.forward * currentSpeed;
  }

  private void Steer() {
    float rotationY = Input.GetAxis("Horizontal") * config.rotationSpeed;

    Vector3 rot = transform.rotation.eulerAngles;
    transform.rotation = Quaternion.Euler(rot.x, rot.y + rotationY, rot.z);
  }

	//	public void Update()
	//{
 //       if (this collided) {
 //           GameOver();
 //       }
	//}

    //public void GameOver() {
    //    blowUpAnimation();
    //        GameoverScreen;
    //        restart ? ();
    //}

		[System.Serializable]
    public class Config {
      public float startingSpeed = 1.0f;
      public float acceleration = 0.001f;
      public float rotationSpeed = 1.0f;
    }


  }
}
