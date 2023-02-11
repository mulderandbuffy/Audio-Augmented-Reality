//Based on tutorial code by Laumania https://gist.github.com/Laumania/abc0c08715974b7e23ec9e5627401be1

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]
public class ParticleSystemAudio : MonoBehaviour
{
    public AudioClip sound;
    
    private ParticleSystem _particleSystem;
    private Dictionary<uint, ParticleSystem.Particle> _particles = new Dictionary<uint, ParticleSystem.Particle>();
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = this.GetComponent<ParticleSystem>();
        if (_particleSystem == null) Debug.Log("Particle System not loaded", this);
        
    }

    // Update is called once per frame
    void Update()
    {
        var liveParticles = new ParticleSystem.Particle[_particleSystem.particleCount];
        _particleSystem.GetParticles(liveParticles);
        
        var delta = getParticleDelta(liveParticles);

        foreach (var particle in delta.Removed)
        {
            StartCoroutine(PlaySound(sound, particle.position));
        }
    }

    private IEnumerator PlaySound(AudioClip clip, Vector3 position)
    {
        var temp = new GameObject("TempAudio")
        {
            transform =
            {
                position = position
            }
        };

        var audio = temp.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.spatialBlend = 1.0f;
        audio.maxDistance = 30.0f;
        audio.pitch = Random.Range(0.9f, 1.1f);
        
        audio.Play();
        Destroy(temp, clip.length);
        yield return new WaitForSeconds(1.0f);
    }

    private ParticleDelta getParticleDelta(ParticleSystem.Particle[] particles)
    {
        var result = new ParticleDelta();

        foreach (var particle in particles)
        {
            ParticleSystem.Particle foundParticle;
            if (_particles.TryGetValue(particle.randomSeed, out foundParticle))
            {
                _particles[particle.randomSeed] = particle;
            }
            else
            {
                result.Added.Add(particle);
                _particles.Add(particle.randomSeed, particle);
            }
        }

        var updatedDictionary = particles.ToDictionary(x => x.randomSeed, x => x);
        var listOfKeys = _particles.Keys.ToList();

        foreach (var key in listOfKeys)
        {
            if (!updatedDictionary.ContainsKey(key))
            {
                result.Removed.Add(_particles[key]);
                _particles.Remove(key);
            }
        }

        return result;
    }
    
    private class ParticleDelta
    {
        public List<ParticleSystem.Particle> Added { get; set; } = new List<ParticleSystem.Particle>();
        public List<ParticleSystem.Particle> Removed { get; set; } = new List<ParticleSystem.Particle>();
    }
}
