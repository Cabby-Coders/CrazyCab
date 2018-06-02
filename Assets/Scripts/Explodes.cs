using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodes : MonoBehaviour {

    [SerializeField] private Config config;

	public void OnCollisionEnter(Collision collision)
	{
        GameObject explosion = config.explosion;
        Instantiate(explosion);
        //explosion.AddComponent<Rigidbody>();
        explosion.transform.position = this.transform.position;
	}


        [System.Serializable]
    public class Config
    {
        public GameObject explosion;
    }
}
