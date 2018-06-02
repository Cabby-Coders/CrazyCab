using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab {
  public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private Config config;

    public Rigidbody rb;

		public void FixedUpdate()
        {

            Vector3 velocity = transform.forward * config.startingSpeed;

            rb.velocity = velocity;
            float rotationY = Input.GetAxis("Horizontal");

            Vector3 rot = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rot.x, rot.y + rotationY, rot.z);


        }
		

    public void Start (){
      rb = GetComponent<Rigidbody>();
      rb.velocity = new Vector3(0, 0, config.startingSpeed);
    }


	private void OnCollisionEnter(Collision collision)
	{

      rb.velocity = new Vector3(0, 0, -1 * config.startingSpeed);
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
    }


  }
}
