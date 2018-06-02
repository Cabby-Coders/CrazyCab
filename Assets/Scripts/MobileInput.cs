using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CabbyCoders.CrazyCab
{
    public class MobileInput : MonoBehaviour
    {

        public float HorizontalAxis;

        // Use this for initialization
        void Start()
        {
            HorizontalAxis = 0;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if ((Application.platform == RuntimePlatform.IPhonePlayer) || (Application.platform == RuntimePlatform.Android))
            {
                HorizontalAxis = Input.acceleration.z;
            }
            else
            {
                HorizontalAxis = Input.GetAxis("Horizontal");
            }
        }
    }
}