using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab {
  public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private Config config;

    private Rigidbody rb;

    public void Start () {
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
