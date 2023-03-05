using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class ModeSwitcher : MonoBehaviour
    {
        private bool _debugMode = false;

        public JSONReader jsonLoader;
        public EffectController effectController;
        public GestureController gestureController;
        public GameObject buttons;

        private Button _toggleWeatherButtons;
        private Button _dataToggle1;
        private Button _dataToggle2;
        private Button _dataToggle3;
        private Button _openMenuButton;

        private Button activeButton;

        private Label _lookUpLabel;

        public GameObject TopText;

        public GameObject modalMenu;
        

        public void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            var doc = GetComponent<UIDocument>();

            _toggleWeatherButtons = root.Q<Button>("DebugButtonsButton");
            _toggleWeatherButtons.clicked += () => ToggleButtons();

            _dataToggle1 = root.Q<Button>("Dataset1");
            _dataToggle2 = root.Q<Button>("Dataset2");
            _dataToggle3 = root.Q<Button>("Dataset3");

            _dataToggle1.clicked += () => SwitchDatasetButton(_dataToggle1, 1);
            _dataToggle2.clicked += () => SwitchDatasetButton(_dataToggle2, 2);
            _dataToggle3.clicked += () => SwitchDatasetButton(_dataToggle3, 3);

            _openMenuButton = root.Q<Button>("MenuButton");
            _openMenuButton.clicked += () => OpenPopup();

            _lookUpLabel = root.Q<Label>("LookUpLabel");
            
            SetActiveButton(GetActiveDatset());
        }

        private void ToggleDebugModes(bool setTo)
        {
            effectController.exitZone();
            effectController.DisableAll();

            _debugMode = setTo;
            gestureController.debugMode = setTo;

            _dataToggle1.SetEnabled(!setTo);
            _dataToggle2.SetEnabled(!setTo);
            _dataToggle3.SetEnabled(!setTo);
            
            TopText.SetActive(!setTo);
            Debug.Log("Debugging: " + _debugMode);
        }

        private void SwitchDatasetButton(Button btn, int fileNo)
        {
            SetInactiveButton();
            SetActiveButton(btn);
            jsonLoader.switchFile(fileNo);
        }

        private void ToggleButtons()
        {
            ToggleDebugModes(!_debugMode);
            buttons.SetActive(!buttons.activeSelf);

            if (_debugMode)
            {
                SetInactiveButton();
                SetActiveButton(_toggleWeatherButtons);
            } else
            {
                SetInactiveButton();
                SetActiveButton(GetActiveDatset());
            }


        }

        private void SetActiveButton(Button btn)
        {

             activeButton = btn;
             btn.style.color = new StyleColor(Color.black);
             btn.style.backgroundColor = new StyleColor(Color.white);

           
        }

        private void SetInactiveButton()
        {

            activeButton.style.color = new StyleColor(Color.white);
            activeButton.style.backgroundColor = new StyleColor(Color.black);
        }

        private Button GetActiveDatset()
        {
            return jsonLoader.currentDataset switch
            {
                "data" => _dataToggle1,
                "data2" => _dataToggle2,
                "data3" => _dataToggle3,
                _ => _dataToggle1
            };
        }

        private void OpenPopup()
        {
            gestureController.RecalibrateSensitivity();
            modalMenu.SetActive(true);
        }

        public void ToggleForecastButtons(bool setTo)
        {

            if (_debugMode)
            {
                ToggleButtons();
            }
            _lookUpLabel.style.opacity = setTo ? 100 : 0;
            
            _toggleWeatherButtons.SetEnabled(setTo);
        }
    }
}