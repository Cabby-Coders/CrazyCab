using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab
{
    public class ObstaclesManager : MonoBehaviour
    {
        [SerializeField] private Config config;
        public Dictionary<OurTuple, RockGenerationBehaviour> tiles;
        public List<RockGenerationBehaviour> initialTiles;

        // Use this for initialization
        void Start()
        {
            tiles = new Dictionary<OurTuple, RockGenerationBehaviour>();

            foreach (var tile in initialTiles)
            {
                tiles.Add(new OurTuple(tile.GetBounds().XCoord(), tile.GetBounds().ZCoord()), tile);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        public RockGenerationBehaviour GetRockThing(int x, int z) {
            return tiles[new OurTuple(x, z)];
        }

        public void GenerateRowPosX(RockGenerationBehaviour.Rectangle currentTile)
        {
            Vector3 centerPosition = new Vector3(currentTile.Center().x + 2 * currentTile.Width(), 0, currentTile.Center().z);
            Vector3 leftPosition = new Vector3(centerPosition.x, 0, centerPosition.z + currentTile.Width());
            Vector3 rightPosition = new Vector3(centerPosition.x, 0, centerPosition.z - currentTile.Width());

            if (!tiles.ContainsKey(new OurTuple((int)centerPosition.x, (int)centerPosition.z)))
            {
                GameObject center = Instantiate(config.obstacle, centerPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)centerPosition.x, (int)centerPosition.z), center.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)leftPosition.x, (int)leftPosition.z)))
            {
                GameObject left = Instantiate(config.obstacle, leftPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)leftPosition.x, (int)leftPosition.z), left.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)rightPosition.x, (int)rightPosition.z)))
            {
                GameObject right = Instantiate(config.obstacle, rightPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)rightPosition.x, (int)rightPosition.z), right.GetComponent<RockGenerationBehaviour>());
            }
        }


        public void GenerateRowNegX(RockGenerationBehaviour.Rectangle currentTile)
        {
            Vector3 centerPosition = new Vector3(currentTile.Center().x - 2 * currentTile.Width(), 0, currentTile.Center().z);
            Vector3 leftPosition = new Vector3(centerPosition.x, 0, centerPosition.z + currentTile.Width());
            Vector3 rightPosition = new Vector3(centerPosition.x, 0, centerPosition.z - currentTile.Width());

            if (!tiles.ContainsKey(new OurTuple((int)centerPosition.x, (int)centerPosition.z)))
            {
                GameObject center = Instantiate(config.obstacle, centerPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)centerPosition.x, (int)centerPosition.z), center.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)leftPosition.x, (int)leftPosition.z)))
            {
                GameObject left = Instantiate(config.obstacle, leftPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)leftPosition.x, (int)leftPosition.z), left.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)rightPosition.x, (int)rightPosition.z)))
            {
                GameObject right = Instantiate(config.obstacle, rightPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)rightPosition.x, (int)rightPosition.z), right.GetComponent<RockGenerationBehaviour>());
            }
        }



        public void GenerateRowPosZ(RockGenerationBehaviour.Rectangle currentTile) {
            Vector3 centerPosition = new Vector3(currentTile.Center().x, 0, currentTile.Center().z + 2 * currentTile.Length());
            Vector3 leftPosition = new Vector3(centerPosition.x + currentTile.Length(), 0, centerPosition.z);
            Vector3 rightPosition = new Vector3(centerPosition.x - currentTile.Length(), 0, centerPosition.z);

            if (!tiles.ContainsKey(new OurTuple((int)centerPosition.x, (int)centerPosition.z))) {
                GameObject center = Instantiate(config.obstacle, centerPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)centerPosition.x, (int)centerPosition.z), center.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)leftPosition.x, (int)leftPosition.z)))
            {
                GameObject left = Instantiate(config.obstacle, leftPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)leftPosition.x, (int)leftPosition.z), left.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)rightPosition.x, (int)rightPosition.z)))
            {
                GameObject right = Instantiate(config.obstacle, rightPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)rightPosition.x, (int)rightPosition.z), right.GetComponent<RockGenerationBehaviour>());
            }
        }

        public void GenerateRowNegZ(RockGenerationBehaviour.Rectangle currentTile)
        {
            Vector3 centerPosition = new Vector3(currentTile.Center().x, 0, currentTile.Center().z - 2 * currentTile.Length());
            Vector3 leftPosition = new Vector3(centerPosition.x + currentTile.Length(), 0, centerPosition.z);
            Vector3 rightPosition = new Vector3(centerPosition.x - currentTile.Length(), 0, centerPosition.z);

            if (!tiles.ContainsKey(new OurTuple((int)centerPosition.x, (int)centerPosition.z)))
            {
                GameObject center = Instantiate(config.obstacle, centerPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)centerPosition.x, (int)centerPosition.z), center.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)leftPosition.x, (int)leftPosition.z)))
            {
                GameObject left = Instantiate(config.obstacle, leftPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)leftPosition.x, (int)leftPosition.z),left.GetComponent<RockGenerationBehaviour>());
            }
            if (!tiles.ContainsKey(new OurTuple((int)rightPosition.x, (int)rightPosition.z)))
            {
                GameObject right = Instantiate(config.obstacle, rightPosition, Quaternion.identity);
                tiles.Add(new OurTuple((int)rightPosition.x, (int)rightPosition.z), right.GetComponent<RockGenerationBehaviour>());
            }
        }



        [System.Serializable]
        public class Config {
            public GameObject obstacle;
        }

        public struct OurTuple {
            public int x;
            public int y;

            public OurTuple(int x, int y) {
                this.x = x;
                this.y = y;
            }

            public bool Equals(OurTuple other) {
                return this.x == other.x && this.y == other.y;
            }
        }

    }

}