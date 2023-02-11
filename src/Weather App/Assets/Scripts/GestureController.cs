using System;
using System.Collections;
using System.Collections.Generic;
using Bose.Wearable;
using UnityEngine;
[RequireComponent(typeof(RotationMatcher))]
public class GestureController : MonoBehaviour
{
    public AudioClip soundEffect;
    public EffectController effectController;
    
    private RotationMatcher _rotationMatcher;
    private float _xpoint;
    private int _timer;

    private bool _inZone = false;
    private bool _playedSound = false;
    private bool _effectSet = false;

    public bool debugMode = false;

    public float triggerPoint = 0.2f;
    public float effectOffDelay = 0.1f;
    
    private float _intermediateTrigger;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        _rotationMatcher = GetComponent<RotationMatcher>();
        if (_rotationMatcher == null)
        {
            print("RotationMatcher not loaded");
        }
        else
        {
            print("RotationMatcher successfully loaded");
            
        }

        if (effectController == null)
        {
            print("Couldn't link effectController");
        }

        _intermediateTrigger = triggerPoint - effectOffDelay;
    }

    // Update is called once per frame
    void Update()
    {
        _xpoint = transform.rotation.x;
            
            if (_xpoint > triggerPoint)
            {
                _inZone = true;
                GestureTriggered();
    
            } else if (_xpoint > _intermediateTrigger) //The intermediate trigger sets the effect un the upswing and gives the user more neck freedom on the downswing
            {
                if (!_effectSet)
                {
                    if (!debugMode)
                    {
                      effectController.SetEffect();
                      _effectSet = true;  
                    }
                    
                }
                
            }
            else
            {
                effectController.exitZone();
                _inZone = false;
                _playedSound = false;
                _effectSet = false;
                
            }
    }

    void GestureTriggered()
    {
        if (!_playedSound)
        {
            StartCoroutine(PlayEffect());
            _playedSound = true;
            effectController.enterZone();
        }
        
    }

    IEnumerator PlayEffect()
    {
        var temp = new GameObject("Gesture_Confirmed");
        var audioSource = temp.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;
        audioSource.Play();
        Destroy(temp, soundEffect.length);
        yield return new WaitForSeconds(soundEffect.length);
    }

    public void SetEffectDelay(float value)
    {
        effectOffDelay = value;
        _intermediateTrigger = triggerPoint - effectOffDelay;
    }
}
