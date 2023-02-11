using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GestureSensitivity : MonoBehaviour
    {
        public float trigger { get; set; }
        public float effectOffDelay;
        public float upperLimit;
        public float lowerLimit;

        public float initialTrigger;
        public float initialDelay;

        public void Start()
        {
            trigger = initialTrigger;
            effectOffDelay = initialDelay;
        }

        public void OnEnable()
        {
            if (trigger > upperLimit || trigger < lowerLimit)
            {
                trigger = lowerLimit;
            }
        }
    }
}