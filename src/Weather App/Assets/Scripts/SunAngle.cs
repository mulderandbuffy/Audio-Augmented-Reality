using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAngle : MonoBehaviour{

    public int START = 08;
    public int END = 20;

    public GameObject origin;

    public bool rotationSet = false;
    
    void OnEnable()
    {
        var timeString = DateTime.Now.ToString("HH.mm");
        var now = Convert.ToDouble(timeString);

        var minutesPassed = Math.Abs(now - START) * 60;
        
        var minutesinTimePeriod = (Math.Abs(END - START)) * 60;
        
        var percenatgeofperiod = determinePercentage(minutesPassed, minutesinTimePeriod);
        var angle = getXpercenatgeofY(percenatgeofperiod, 180);

        if (!rotationSet)
        {
           Rotate(angle); 
        }
        
    }

    double determinePercentage(double parts, double whole)
    {
        return (parts / whole) * 100;
    }

    double getXpercenatgeofY(double percent, double whole)
    {
        return (percent / 100) * whole;
    }

    private void Rotate(double angle)
    {
        transform.RotateAround(origin.transform.position, new Vector3(0, 0, 1), (float)angle);
        rotationSet = true;
    }
}
