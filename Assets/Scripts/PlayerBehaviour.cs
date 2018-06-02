using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab {
  public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private Config config;

    public Rigidbody rb;

		public void FixedUpdate()
        {
            Input.GetAxis("Horizontal");
            Debug.Log(Input.GetAxis("Horizontal"));

            Vector3 velocity = transform.forward * config.startingSpeed;

            rb.velocity = velocity;
            //if (KeyCode.LeftArrow{
            //transform.rotation
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
