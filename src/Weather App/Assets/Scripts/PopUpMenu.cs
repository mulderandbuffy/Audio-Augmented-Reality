using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class PopUpMenu : MonoBehaviour
    {

        public GestureController gestureController;
        public RoundViewController roundView;

        private Button closeButton;
        private Button helpButton;
        private Slider sensitivitySlider;
        private Slider delaySlider;
        
        private RadioButtonGroup forecastChoices;
        private bool _forecastChoiceChanged;
        

        public GameObject helpMenu;
        public void OnEnable()
        {
            //gestureController.RecalibrateSensitivityBounds();
            
            var root = GetComponent<UIDocument>().rootVisualElement;

            closeButton = root.Q<Button>("CloseButton");
            closeButton.clicked += () => Close();

            sensitivitySlider = root.Q<Slider>("SensitivitySlider");
            SetSensitivityOptions();

            delaySlider = root.Q<Slider>("DelaySlider");
            delaySlider.value = gestureController.effectOffDelay;

            forecastChoices = root.Q<RadioButtonGroup>("RoundViewChoices");
            forecastChoices.value = (int)roundView.mode;

            _forecastChoiceChanged = false;

            helpButton = root.Q<Button>("HelpBtn");
            helpButton.clicked += () => OpenHelp();


        }

        private void Close()
        {
            gameObject.SetActive(false);
            //gestureController.triggerPoint = sensitivitySlider.value;
           //gestureController.SetEffectDelay(delaySlider.value);

            if (forecastChoices.value != (int)roundView.mode)
            {
                _forecastChoiceChanged = true;
                roundView.mode = (ForecastViewChoice)forecastChoices.value;
                roundView.PointsChanged();
            }
        }

        private void OnDisable()
        {
            gestureController.triggerPoint = sensitivitySlider.value;
            gestureController.SetEffectDelay(delaySlider.value);

            if (_forecastChoiceChanged)
            {
                
            }
        }

        private void OpenHelp()
        {
            helpMenu.SetActive(true);
        }

        private void SetSensitivityOptions()
        {
            sensitivitySlider.value = gestureController.triggerPoint;
            sensitivitySlider.lowValue = gestureController.lowerTrigger;
            sensitivitySlider.highValue = gestureController.upperTrigger;
        }
    }
}