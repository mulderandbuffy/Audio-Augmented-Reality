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
        private Slider sensitivitySlider;
        private Slider delaySlider;
        
        private RadioButtonGroup forecastChoices;
        private bool _foreceastChoiceChanged;
        public void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            closeButton = root.Q<Button>("CloseButton");
            closeButton.clicked += () => Close();

            sensitivitySlider = root.Q<Slider>("SensitivitySlider");
            sensitivitySlider.value = gestureController.triggerPoint;

            delaySlider = root.Q<Slider>("DelaySlider");
            delaySlider.value = gestureController.effectOffDelay;

            forecastChoices = root.Q<RadioButtonGroup>("RoundViewChoices");
            forecastChoices.value = (int)roundView.mode;

            _foreceastChoiceChanged = false;


        }

        private void Close()
        {
            gameObject.SetActive(false);
            //gestureController.triggerPoint = sensitivitySlider.value;
           //gestureController.SetEffectDelay(delaySlider.value);

            if (forecastChoices.value != (int)roundView.mode)
            {
                _foreceastChoiceChanged = true;
                roundView.mode = (ForecastViewChoice)forecastChoices.value;
                roundView.PointsChanged();
            }
        }

        private void OnDisable()
        {
            gestureController.triggerPoint = sensitivitySlider.value;
            gestureController.SetEffectDelay(delaySlider.value);

            if (_foreceastChoiceChanged)
            {
                
            }
        }
    }
}