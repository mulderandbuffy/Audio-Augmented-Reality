using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public GameObject sunObject;
    public GameObject windObject;
    public GameObject thunderObject;
    public GameObject snowObject;
    public GameObject rainObject;
    public GameObject blizzardObject;
    public GameObject cloudObject;
    public GameObject heavyRainObject;

    public JSONReader JSONController;
    public GameObject helpArrows;

    public WindAngleController WindController;
    private GameObject _currentlyActive = null;

    private void Start()
    {
        DisableAll();
        print("Start");
    }

    public void DisableAll()
    {
        if (_currentlyActive != null)
        {
            _currentlyActive.SetActive(false);
            
        }
        
        _currentlyActive = null;
    }
    
    public void ToggleObject(GameObject obj){
        if (obj == _currentlyActive)
        {
            DisableAll();
        }
        else
        {
            DisableAll();
            if (obj == windObject)
            {
                WindController.currentDirection = WindDirection.NONE;
            }
            _currentlyActive = obj;
        }
        
    }

    private string CurrentWeatherString()
    {
        return _currentlyActive.name;
    }

    private void LogCurrentEffect()
    {
        DebugDisplay.CreateLog("Current Effect: " + CurrentWeatherString());
    }
    
    public void exitZone(){
        
        if (_currentlyActive != null)
        {
            _currentlyActive.SetActive(false);
        }
    }

    public void enterZone()
    {
        if (_currentlyActive != null)
        {
            _currentlyActive.SetActive(true);
            
        }
    }

    public void SetEffect()
    {
        var currentEffect = JSONController.queryJSON();
        switch (currentEffect.effect)
        {
            case weatherEffect.WIND:
                _currentlyActive = windObject;
                WindController.currentDirection = currentEffect.windAngle;
                break;
            case weatherEffect.SUN:
                _currentlyActive = sunObject;
                break;
            case weatherEffect.RAIN:
                _currentlyActive = rainObject;
                break;
            case weatherEffect.SNOW:
                _currentlyActive = snowObject;
                break;
            case weatherEffect.CLOUD:
                _currentlyActive = cloudObject;
                break;
            case weatherEffect.THUNDER:
                _currentlyActive = thunderObject;
                break;
            case weatherEffect.BLIZZARD:
                _currentlyActive = blizzardObject;
                break;
            case weatherEffect.HEAVYRAIN:
                _currentlyActive = heavyRainObject;
                break;
            default:
                _currentlyActive = null;
                break;
        }
    }
    
    
}
