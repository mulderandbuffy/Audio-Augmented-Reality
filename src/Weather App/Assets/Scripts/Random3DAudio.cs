using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Random3DAudio : MonoBehaviour
    {
        public AudioClip sound1;
        
        public float range;

        public float maxAudioRange = 30f;
        public float minAudioRange = 5f;

        public float minWait;
        public float maxWait;

        public float minPitch;
        public float maxPitch;
        public float masterVolume;
        
        private bool _isPlaying;
        void Start()
        {
            _isPlaying = false;
        }
        void OnEnable()
        {
            _isPlaying = false;
        }

        private void OnDisable()
        {
            _isPlaying = false;
        }

        void Update()
        {
            if (!_isPlaying)
            {
                 var point = ChoosePoint(range);
                 StartCoroutine(PlayAndWait(sound1, point));
            }
           
        }

        private IEnumerator PlayAndWait(AudioClip clip, Vector3 point)
        {
            _isPlaying = true;
            PlayClipAt(clip, point);
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            _isPlaying = false;
        }

        private void PlayClipAt(AudioClip clip, Vector3 point)
        {
            
            //found at https://answers.unity.com/questions/316575/adjust-properties-of-audiosource-created-with-play.html
            var temp = new GameObject("TempAudio")
            {
                transform =
                {
                    position = point
                }
            };
            var audioSource = temp.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.spatialBlend = 1.0f;
            audioSource.maxDistance = Random.Range(maxAudioRange-5, maxAudioRange);
            audioSource.minDistance = minAudioRange;
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.volume = masterVolume;

            audioSource.Play();
            Destroy(temp, clip.length);
        }

        private Vector3 ChoosePoint(float distance)
        {
            Vector3 pos = transform.position;
            var x = Random.Range(pos.x - distance, pos.x + distance);
            var y = Random.Range(pos.y - distance, pos.y + distance);
            var z = Random.Range(pos.z - distance, pos.z + distance);

            return new Vector3(x, y, z);
        }
    }
