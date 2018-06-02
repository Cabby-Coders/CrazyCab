using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CabbyCoders.CrazyCab {
  public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private Config config;

        private bool gameOver = false;
        private float currentSpeed;
        public Rigidbody rb;
        private MobileInput mobileInput;


    public void Start (){
      rb = GetComponent<Rigidbody>();
      rb.velocity = new Vector3(0, 0, config.startingSpeed);
      mobileInput = GetComponent<MobileInput>();
      currentSpeed = config.startingSpeed;
    }

		public void FixedUpdate() {
      Accelerate();
      GoForward();
      Steer();
      ResetPlusX();
      ResetPlusZ();
      SetSpeedText();      
    }

        public void SetSpeedText() {
            config.speedText.text = rb.velocity.magnitude.ToString();
        }
	
        public bool isGameOver(){
            return gameOver;
        }
	private void OnCollisionEnter(Collision collision)
	{
            config.gameOverText.SetActive(true);
            gameOver = true;

            float x = this.transform.position.x + 2;
            float y = this.transform.position.y - 1;
            float z = this.transform.position.z;
            Vector3 position = new Vector3(x, y, z);


            GameObject explosion = config.explosion;
            Instantiate(explosion);
            explosion.transform.position = position;


            GameObject force = config.force;
            Instantiate(force);
            force.transform.position = position;
    }

  private void Accelerate() {
    currentSpeed += config.acceleration;
  }

  private void GoForward() {
    rb.velocity = transform.forward * currentSpeed;
  }

  private void Steer() {
float rotationY = mobileInput.HorizontalAxis * config.rotationSpeed;

    Vector3 rot = transform.rotation.eulerAngles;
    transform.rotation = Quaternion.Euler(rot.x, rot.y + rotationY, rot.z);
  }

  private void ResetPlusX(){
    if(transform.position.x >= config.generator.GetBounds().maxX)
    {
      Vector3 currentPos =  transform.position;
      float newX = transform.position.x - config.generator.GetBounds().Width();
      transform.position = new Vector3(newX, currentPos.y, currentPos.z);
    }
  }

   private void ResetPlusZ(){
    if(transform.position.z >= config.generator.GetBounds().maxZ)
    {
      Vector3 currentPos =  transform.position;
      float newZ = transform.position.z - config.generator.GetBounds().Length();
      transform.position = new Vector3(currentPos.x, currentPos.y, newZ);
    }
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
      public GameObject gameOverText;
      public GameObject explosion;
      public GameObject force;
      public Text speedText;
      public RockGenerationBehaviour generator;
    }


  }
}
