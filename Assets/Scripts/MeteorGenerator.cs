using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab
{
    public class MeteorGenerator : MonoBehaviour
    {

        [SerializeField]
        private Config config;

        void Start()
        {
            StartCoroutine(spawnMeteor());
        }

        private Vector3 randomPosition()
        {
            RockGenerationBehaviour.Rectangle currentTileBounds = config.rockGenerationBehaviour.GetBounds();
            float x = Random.Range(currentTileBounds.minX, currentTileBounds.maxX);
            float y = 100f;
            float z = Random.Range(currentTileBounds.minZ, currentTileBounds.maxZ);
            return new Vector3(x, y, z);
        }

        private IEnumerator spawnMeteor()
        {
            yield return new WaitForSecondsRealtime(3);
            Vector3 position = randomPosition();
            GameObject meteor = config.rockGenerationBehaviour.GenerateRock(position, config.meteors);
            Rigidbody meteorRigidbody = meteor.AddComponent<Rigidbody>();

            StartCoroutine(spawnMeteor());
        }

        void Update()
        {

        }

        [System.Serializable]
        public class Config
        {
            public CabbyCoders.CrazyCab.RockGenerationBehaviour rockGenerationBehaviour;
            public GameObject[] meteors;
        }
    }

}
