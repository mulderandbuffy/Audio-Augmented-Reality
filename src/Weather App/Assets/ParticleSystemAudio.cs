using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemAudio : MonoBehaviour
{
    public AudioClip sound;
    
    private ParticleSystem _particleSystem;
    private int _currentParticles = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = this.GetComponent<ParticleSystem>();
        if (_particleSystem == null) Debug.Log("Particle System not loaded", this);
        

    }

    // Update is called once per frame
    void Update()
    {
        var amount = Mathf.Abs(_currentParticles - _particleSystem.particleCount);
        if (_particleSystem.particleCount < _currentParticles)
        {
            //Play sound
        }
    }
}
