using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DayNightSwitcher : MonoBehaviour
    {
        public GameObject day;
        public GameObject night;

        public int sunrise = 8;
        public int sunset = 20;

        private GameObject _currentlyActive;

        public void Start()
        {
            if (sunset < sunrise)
            {
                sunset = sunrise + 12;
            }
        }
        public void OnEnable()
        {
            var now = DateTime.Now.Hour;
            if (now >= sunrise && now < sunset)
            {
                if (_currentlyActive != day)
                {
                    night.SetActive(false); 
                    day.SetActive(true);
                }
                
            }
            else
            {
                if (_currentlyActive != night)
                {
                     day.SetActive(false);
                     night.SetActive(true);
                }
               
            }
        }
    }
}