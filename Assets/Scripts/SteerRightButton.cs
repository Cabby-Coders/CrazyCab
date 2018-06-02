using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab
{
    public class SteerRightButton : MonoBehaviour
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

        public void OnButtonDown() {
            Debug.Log("Button Down");
            config.player.GetInput().StartTurnRight();
        }


        public void OnButtonUp() {
            Debug.Log("Button Up");
            config.player.GetInput().StopTurnRight();
        }

        [System.Serializable]
        public class Config
        {
            public PlayerBehaviour player;
        }
    }
}