using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnClickStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void startGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
  }
}
