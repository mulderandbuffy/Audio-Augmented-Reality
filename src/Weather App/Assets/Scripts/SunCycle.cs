using System;
using UnityEngine;

/**
 * Code adapted from repository at https://github.com/IChoMo/RealWorldDayNightCycle/blob/main/RealWorldDayNight.cs and YouTube tutorial by Kind Code at
 * https://youtu.be/yVDkdoUx6aE
 */
namespace DefaultNamespace
{
    public class SunCycle : MonoBehaviour
    {
        private int CurrentHour;
        private float CurrentMinute;

        public GameObject Sun;
        private Vector3 eulerRotation;
        public float SunRiseTime = 8;
        public float SunSetTime = 8;
        private float TimeIntoDay;
        private float SolarDayLength;

        void Start()
        {
            //sets the initial sun rotation to its current rotation
            eulerRotation = Sun.transform.rotation.eulerAngles;
        }
        

        private void OnEnable()
        {
            CurrentHour = System.DateTime.Now.Hour;
            CurrentMinute = System.DateTime.Now.Minute;

            SunTime(13, CurrentMinute);
        }

        void SunTime(int Hour, float Minute)
        {
            //depending on when the sunrise and sunset is, will determine how long the day is
            SolarDayLength = (12 - SunRiseTime) + SunSetTime;

            TimeIntoDay = Hour + Minute / 60;

            var SolarEnd = SunRiseTime + SolarDayLength;

            if (TimeIntoDay < SunRiseTime)
            {
                transform.RotateAround(transform.position, new Vector3(0, 0, 1), 185);
            }
            else if (TimeIntoDay > SolarEnd)
            {
                //transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 185);
                transform.RotateAround(transform.position, new Vector3(0, 0, 1), 185);
            }
            else
            {
                //if time is in solar window
                var cTime = TimeIntoDay - SunRiseTime;

                //sets sun rotation based on 185 degrees of rotation (I find works nicely for unity's Directional light) and the percentage of time into the Solarday
                //transform.rotation = Quaternion.Euler(cTime * 185 / SolarDayLength, eulerRotation.y, eulerRotation.z);
                transform. transform.RotateAround(transform.position, new Vector3(0, 0, 1), cTime * 185 / SolarDayLength);
            }
        }
    }
}