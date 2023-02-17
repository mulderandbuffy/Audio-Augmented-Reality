using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraSwitcher : MonoBehaviour
    {
        public GameObject frontCam;
        public GameObject topCam;
        

        private void Start()
        {
            SwitchCamera(1);
        }

        public void SwitchCamera(int switchTo)
        {
            switch (switchTo)
            {
                case 1: //MainCam
                    frontCam.SetActive(true);
                    topCam.SetActive(false);
                    break;
                case 2: //Top Cam - Forecast View
                    topCam.SetActive(true);
                    frontCam.SetActive(false);
                    break;
                default:
                    frontCam.SetActive(true);
                    topCam.SetActive(false);
                    break;
            }
        }
    }
}