using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab
{
    public class SteerLeftButton : MonoBehaviour
    {

        [SerializeField] private Config config;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnButtonDown()
        {
            config.player.GetInput().StartTurnLeft();
        }


        public void OnButtonUp()
        {
            config.player.GetInput().StopTurnLeft();
        }

        [System.Serializable]
        public class Config
        {
            public PlayerBehaviour player;
        }
    }
}
