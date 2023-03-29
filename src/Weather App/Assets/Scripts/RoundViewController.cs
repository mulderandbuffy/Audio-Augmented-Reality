using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class RoundViewController : MonoBehaviour
    {
        public int circleSize;
        public int noPoints;

        public GameObject origin;
        public JSONReader dataLoader;

        public GameObject rainPrefab;
        public GameObject heavyRainPrefab;
        public GameObject sunPrefab;
        public GameObject windPrefab;
        public GameObject snowPrefab;
        public GameObject blizzardPrefab;
        public GameObject thunderPrefab;
        public GameObject cloudPrefab;

        private ArrayList points = new ArrayList();
        private ArrayList activeSounds = new ArrayList();
        private ArrayList tempSounds = new ArrayList();

        private bool loaded;
        private bool _active = false;

        public CameraSwitcher CameraSwitcher;

        public EffectController effectController;
        public GestureController gestureController;

        public AudioClip openingSound;
        public AudioClip closingSound;

        public ModeSwitcher menuButtons;

        public ForecastViewChoice mode = ForecastViewChoice.EIGHT_HOURS;
        

        public void OnEnable()
        {
            gestureController.Toggle();
            _active = true;
            
            PointsChanged();
            
            if (loaded)
            {
                StartCoroutine(PlaySound(true));
                CameraSwitcher.SwitchCamera(2);
                SpawnEffects();
            }
            
        }

        public void CreatePoints()
        {
            var tmp = new ArrayList();
            for (int i = 0; i < noPoints; i++)
            {
                CreatePoint(i, tmp);
            }

            points = SortPoints(tmp);
            
        }

        public ArrayList SortPoints(ArrayList list)
        {
            var output = new ArrayList();
            var slice = noPoints / 4; //1

            output.Add(list[slice]); //1

            for (int i = slice-1; i >= 0; i--) //0
            {
                output.Add(list[i]);
            }

            for (int i = noPoints-1; i > slice; i--) //3 //2
            {
                output.Add(list[i]);
            }
            
            return output;

        }

        public void CreatePoint(int current, ArrayList list)
        {
            var theta = (Math.PI * 2) / noPoints;
            var angle = theta * current;

            list.Add(new Vector3((float)(circleSize * Math.Cos(angle)), origin.transform.position.y,
                (float)(circleSize * Math.Sin(angle))));
        }

        private void DestroyActiveSounds()
        {
            if (activeSounds.Count > 0)
            {
               foreach (GameObject prefab in activeSounds)
               {
                   DestroyImmediate(prefab);
               }
               
               activeSounds.Clear(); 
            }
            
        }

        public void LoadEffects()
        {
            loaded = false;
            var effectList = dataLoader.getNextXEntries(noPoints);
            
            tempSounds.Clear();
            for (int i = 0; i < noPoints; i++)
            {
                var effect = ((EffectEntry)effectList[i]).effect;

                switch (effect)
                {
                    case weatherEffect.SUN:
                        tempSounds.Add(sunPrefab);
                        break;
                    case weatherEffect.RAIN:
                        tempSounds.Add(rainPrefab);
                        break;
                    case weatherEffect.HEAVYRAIN:
                        tempSounds.Add(heavyRainPrefab);
                        break;
                    case weatherEffect.WIND:
                        tempSounds.Add(windPrefab);
                        break;
                    case weatherEffect.SNOW:
                        tempSounds.Add(snowPrefab);
                        break;
                    case weatherEffect.BLIZZARD:
                        tempSounds.Add(blizzardPrefab);
                        break;
                    case weatherEffect.THUNDER:
                        tempSounds.Add(thunderPrefab);
                        break;
                    case weatherEffect.CLOUD:
                        tempSounds.Add(cloudPrefab);
                        break;
                    default:
                        break;
                }
            }

            loaded = true;

        }

        private void OnDisable()
        {
            DestroyActiveSounds();
            gestureController.Toggle();
            _active = false;
        }

        private void SpawnEffects()
        {
            if (tempSounds.Count > 0 && points.Count > 0)
            {
                for (int i = 0; i < noPoints; i++)
                {
                    var newSound=  Instantiate((GameObject)tempSounds[i], (Vector3)points[i], Quaternion.identity);
                    activeSounds.Add(newSound);
                }
            }
            
        }

        public void Toggle()
        {
            if (_active)
            {
                StartCoroutine(PlaySound(false));
                CameraSwitcher.SwitchCamera(1);
                this.gameObject.SetActive(false);
                menuButtons.ToggleForecastButtons(true);
            }
            else
            {
                this.gameObject.SetActive(true);
                menuButtons.ToggleForecastButtons(false);
            }
        }

        public void PointsChanged()
        {
            switch (mode)
            {
                case ForecastViewChoice.FOUR_HOURS:
                    noPoints = 4;
                    break;
                case ForecastViewChoice.EIGHT_HOURS:
                    noPoints = 8;
                    break;
                case ForecastViewChoice.TWELVE_HOURS:
                    noPoints = 12;
                    break;
                default:
                    noPoints = 4;
                    mode = ForecastViewChoice.FOUR_HOURS;
                    break;
            }
            CreatePoints();
            LoadEffects();
            
        }

        public void Refresh()
        {
            DestroyActiveSounds();
            SpawnEffects();
        }

        IEnumerator PlaySound(bool isOpening)
        {
            var temp = new GameObject("RoundViewInteract");
            var audioSource = temp.AddComponent<AudioSource>();

            var soundEffect = isOpening ? openingSound : closingSound;
            audioSource.clip = soundEffect;
            audioSource.volume = 0.5f;
            
            audioSource.Play();
            Destroy(temp, soundEffect.length);
            yield return new WaitForSeconds(soundEffect.length);
        }

    }

    public enum ForecastViewChoice
    {
        FOUR_HOURS, //0
        EIGHT_HOURS, //1
        TWELVE_HOURS //2
    }
}