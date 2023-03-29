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
    public float upperTrigger = 0.3f;
    public float lowerTrigger = 0.05f;
    public float effectOffDelay = 0.1f;

    private bool _triggerValueSet = false;

    private float _intermediateTrigger;

    public bool isEnabled = true;

    public WearableControl _wearableControl;

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
        if (isEnabled)
        {
            _xpoint = transform.rotation.x;
            DebugDisplay.SetText(_xpoint.ToString());

            if (_xpoint > triggerPoint)
            {
                _inZone = true;
                GestureTriggered();

            }
            else if
                (_xpoint >
                 _intermediateTrigger) //The intermediate trigger sets the effect on the upswing and gives the user more neck freedom on the downswing
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

            if (!_triggerValueSet)
            {
                SetInitialTrigger();
            }
        }
        else
        {
            DebugDisplay.SetText("");
        }

    }

    public void Toggle()
    {
        if (isEnabled)
        {
            effectController.exitZone();
            _inZone = false;
            _playedSound = false;
            _effectSet = false;

            isEnabled = false;
        }
        else
        {
            isEnabled = true;
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

    private void SetInitialTrigger()
    {
        if (_wearableControl.ConnectedDevice != null)
        {
            var product = _wearableControl.ConnectedDevice.Value.GetProductType();
            switch (product)
            {
                case ProductType.Frames:
                    triggerPoint = 0.2f;
                    upperTrigger = 0.3f;
                    lowerTrigger = 0.05f;
                    break;
                case ProductType.NoiseCancellingHeadphones700:
                    triggerPoint = 0.1f;
                    upperTrigger = 0.2f;
                    lowerTrigger = 0.04f;
                    break;
                default:
                    triggerPoint = 0.18f;
                    upperTrigger = 0.25f;
                    lowerTrigger = 0.045f;
                    break;
            }

            _triggerValueSet = true;
            print(triggerPoint);

            _intermediateTrigger = triggerPoint - effectOffDelay;
        }
    }

    public void RecalibrateSensitivity()
    {
        if (_wearableControl.ConnectedDevice != null)
        {
            var product = _wearableControl.ConnectedDevice.Value.GetProductType();
            switch (product)
            {
                case ProductType.Frames:
                    upperTrigger = 0.3f;
                    lowerTrigger = 0.05f;
                    break;
                case ProductType.NoiseCancellingHeadphones700:
                    upperTrigger = 0.2f;
                    lowerTrigger = 0.04f;
                    break;
                default:
                    upperTrigger = 0.25f;
                    lowerTrigger = 0.045f;
                    break;
            }

            if (triggerPoint > upperTrigger)
            {
                triggerPoint = upperTrigger;
            } else if (triggerPoint < lowerTrigger)
            {
                triggerPoint = lowerTrigger;
            }
            
            print(product);
        }
    }


}
