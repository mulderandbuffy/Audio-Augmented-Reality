using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class PopUpMenu : MonoBehaviour
    {

        public GestureController gestureController;

        private Button closeButton;
        private Slider sensitivitySlider;
        private Slider delaySlider;
        public void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            closeButton = root.Q<Button>("CloseButton");
            closeButton.clicked += () => Close();

            sensitivitySlider = root.Q<Slider>("SensitivitySlider");
            sensitivitySlider.value = gestureController.triggerPoint;

            delaySlider = root.Q<Slider>("DelaySlider");
            delaySlider.value = gestureController.effectOffDelay;
        }

        private void Close()
        {
            gameObject.SetActive(false);
            gestureController.triggerPoint = sensitivitySlider.value;
            gestureController.SetEffectDelay(delaySlider.value);
        }
    }
}