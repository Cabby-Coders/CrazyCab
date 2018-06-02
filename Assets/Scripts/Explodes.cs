using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour {



    [SerializeField] private Config config;
   
	public void OnCollisionEnter(Collision collision)
	{
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


        [System.Serializable]
    public class Config
    {
        public GameObject explosion;
        public GameObject force;
    }
}
