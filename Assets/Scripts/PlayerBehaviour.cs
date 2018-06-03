using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CabbyCoders.CrazyCab {
  public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private Config config;
    private bool gameOver = false;
    private float currentSpeed;
    public Rigidbody rb;
    private MobileInput mobileInput;

        private RockGenerationBehaviour currentTile;

    public void Start (){
      rb = GetComponent<Rigidbody>();
      rb.velocity = new Vector3(0, 0, config.startingSpeed);
      mobileInput = GetComponent<MobileInput>();
      currentSpeed = config.startingSpeed;

            currentTile = config.generator;
    }

	public void FixedUpdate() {
      if(!gameOver){
        Accelerate();
        GoForward();
        Steer();
        ResetPlusX();
        ResetPlusZ();
        ResetMinusX();
        ResetMinusZ();
        SetSpeedText();
      }

    }

        public void SetSpeedText() {
            config.speedText.text = rb.velocity.magnitude.ToString();
        }

    public bool isGameOver(){
        return gameOver;
    }

        public MobileInput GetInput() {
            return mobileInput;
        }

	private void OnCollisionEnter(Collision collision)
	{
        config.gameOverText.SetActive(true);
        gameOver = true;

        GameObject explosion = config.explosion;
        Instantiate(explosion, this.transform.position + new Vector3(2, -1, 0), this.transform.rotation);

        GameObject force = config.force;
        Instantiate(force, this.transform.position, this.transform.rotation);

        StartCoroutine(delayReset());
    }

  private void Accelerate() {
    if (currentSpeed < 220) {
        currentSpeed = currentSpeed + (config.acceleration * 0.001f);
        config.acceleration += 1f;        
    }        
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
            if(transform.position.x >= currentTile.GetBounds().maxX)
    {
                //Vector3 currentPos =  transform.position;
                //float newX = transform.position.x - currentTile.GetBounds().Width();
                //transform.position = new Vector3(newX, currentPos.y, currentPos.z);

                config.obstaclesManager.GenerateRowPosX(currentTile.GetBounds());

                Debug.Log(currentTile.GetBounds().XCoord() + (int)currentTile.GetBounds().Width());
                currentTile = config.obstaclesManager.GetRockThing(
                    currentTile.GetBounds().XCoord() + (int)currentTile.GetBounds().Width(),
                    currentTile.GetBounds().ZCoord()
                );
    }
  }

  private void ResetMinusX(){
            if(transform.position.x <= currentTile.GetBounds().minX){
      //Vector3 currentPos = transform.position;
      //          float newX = transform.position.x + currentTile.GetBounds().Width();
      //transform.position = new Vector3(newX, currentPos.y, currentPos.z);


                config.obstaclesManager.GenerateRowNegX(currentTile.GetBounds());

                currentTile = config.obstaclesManager.GetRockThing(
                    currentTile.GetBounds().XCoord() - (int)currentTile.GetBounds().Width(),
                    currentTile.GetBounds().ZCoord()
                );
    }
  }

   private void ResetPlusZ(){
            if(transform.position.z >= currentTile.GetBounds().maxZ)
    {
      //Vector3 currentPos =  transform.position;
      //          float newZ = transform.position.z - currentTile.GetBounds().Length();
      //transform.position = new Vector3(currentPos.x, currentPos.y, newZ);

                config.obstaclesManager.GenerateRowPosZ(currentTile.GetBounds());

                currentTile = config.obstaclesManager.GetRockThing(
                    currentTile.GetBounds().XCoord(),
                    currentTile.GetBounds().ZCoord() + (int)currentTile.GetBounds().Length()
                );
    }
  }

  private void ResetMinusZ(){
            if(transform.position.z <= currentTile.GetBounds().minZ){
      //Vector3 currentPos = transform.position;
      //          float newZ = transform.position.z + currentTile.GetBounds().Width();
      //transform.position = new Vector3(currentPos.x, currentPos.y, newZ);


                config.obstaclesManager.GenerateRowNegZ(currentTile.GetBounds());
                currentTile = config.obstaclesManager.GetRockThing(
                    currentTile.GetBounds().XCoord(),
                    currentTile.GetBounds().ZCoord() - (int)currentTile.GetBounds().Length()
                );
    }
  }

    private IEnumerator delayReset()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(0);
    }


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
      public ObstaclesManager obstaclesManager;
    }

  }
}
