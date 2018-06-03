using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab {
  public class RockGenerationBehaviour : MonoBehaviour {

    [SerializeField] private Config config;
    private Rectangle bounds;

    public void Awake () {
      this.bounds = new Rectangle(config.ground.GetComponent<Renderer>().bounds);
      Generate();
      //GenerateClones();
    }

    public void Generate() {
      for(int i = 0; i < config.numberOfRocks; ++i) {
        Vector3 location = GenerateLocation();
        GenerateRock(location, config.rocks);
      }
    }

    public void GenerateClones() {
      float w = bounds.Width();
      float l = bounds.Length();
      Clone(0, 0);
    }

    public Rectangle GetBounds() {
      return bounds;
    }

    public Vector3 GenerateLocation() {
      return new Vector3(
        Random.Range(bounds.minX, bounds.maxX),
        0.5f,
        Random.Range(bounds.minZ, bounds.maxZ)
      );
    }

    public GameObject GenerateRock(Vector3 location, GameObject[] rocks) {
      int rock = Random.Range(0, rocks.Length - 1);
      return Instantiate(rocks[rock], location, Quaternion.identity, config.rockGroup.transform);
    }

    private void Clone(float x, float z) {
      Vector3 location = new Vector3(x, 1f, z);
      Instantiate(config.rockGroup, location, Quaternion.identity, transform);
      //Instantiate(config.ground, location, Quaternion.identity, transform);
    }

    [System.Serializable]
    public class Config {
      public GameObject ground;
      public int numberOfRocks;
      public GameObject rockGroup;
      public GameObject[] rocks;      
    }

    [System.Serializable]
    public class Rectangle {
            private Bounds bounds;
      public float minX = -10.0f;
      public float minZ = -10.0f;
      public float maxX = 10.0f;
      public float maxZ = 10.0f;

      public Rectangle(Bounds bounds) {
        minX = bounds.min.x;
        minZ = bounds.min.z;

        maxX = bounds.max.x;
        maxZ = bounds.max.z;

                this.bounds = bounds;
      }

      public float Width() {
        return maxX - minX;
      }

      public float Length() {
        return maxZ - minZ;
      }

            public Vector3 Center() {
                return bounds.center;
            }

            public int XCoord() {
                return (int)Center().x;
            }
            public int ZCoord()
            {
                return (int)Center().z;
            }
    }
  }
}