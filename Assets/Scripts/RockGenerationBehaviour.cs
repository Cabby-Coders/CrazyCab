using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab {
  public class RockGenerationBehaviour : MonoBehaviour {

    [SerializeField] private Config config;

    public void Start () {
      Generate();
      Clone();
    }

    public void Generate() {
      for(int i = 0; i < config.numberOfRocks; ++i) {
        Vector3 location = GenerateLocation();
        GenerateRock(location);
      }
    }

    public Vector3 GenerateLocation() {
      return new Vector3(
        Random.Range(config.bounds.minX, config.bounds.maxX),
        0,
        Random.Range(config.bounds.minZ, config.bounds.maxZ)
      );
    }

    public GameObject GenerateRock(Vector3 location) {
      int rock = Random.Range(0, config.rocks.Length - 1);
      return Instantiate(config.rocks[rock], location, Quaternion.identity, config.rockGroup.transform);
    }

    private void Clone() {
      Vector3 location = new Vector3(config.bounds.Width(), 0, 0);
      Instantiate(config.rockGroup, location, Quaternion.identity, transform);
    }

    [System.Serializable]
    public class Config {
      public Rectangle bounds;
      public int numberOfRocks;
      public GameObject rockGroup;
      public GameObject[] rocks;
    }

    [System.Serializable]
    public class Rectangle {
      public float minX = -10.0f;
      public float minZ = -10.0f;
      public float maxX = 10.0f;
      public float maxZ = 10.0f;

      public float Width() {
        return maxX - minX;
      }

      public float Length() {
        return maxZ - minZ;
      }
    }
  }
}