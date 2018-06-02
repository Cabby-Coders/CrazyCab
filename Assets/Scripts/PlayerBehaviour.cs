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

    [System.Serializable]
    public class Config {
      public float startingSpeed = 1.0f;
    }

  }
}
