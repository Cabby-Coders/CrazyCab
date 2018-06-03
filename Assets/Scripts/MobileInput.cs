using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab
{
    public class MobileInput : MonoBehaviour
    {

        private bool isTurningRight;
        private bool isTurningLeft;
        public float HorizontalAxis;

        // Use this for initialization
        void Start()
        {
            HorizontalAxis = 0;
            isTurningRight = false;
            isTurningLeft = false;
        }

        public void StartTurnRight() {
            isTurningRight = true;
        }

        public void StopTurnRight() {
            isTurningRight = false;
        }

        public void StartTurnLeft()
        {
            isTurningLeft = true;
        }

        public void StopTurnLeft()
        {
            isTurningLeft = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
                if(isTurningRight) {
                    HorizontalAxis = 1;
                } else if(isTurningLeft) {
                    HorizontalAxis = -1;
                }else {
                    HorizontalAxis = 0;
                }
        }
    }
}