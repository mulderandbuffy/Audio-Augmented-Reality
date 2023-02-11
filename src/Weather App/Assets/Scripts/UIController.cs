using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public EffectController controller;
    public GestureController gestureController;

    private Button sunButton;
    private Button windButton;
    private Button thunderButton;
    private Button snowButton;
    private Button rainButton;
    private Button blizzButton;
    private Button cloudButton;
    private Button heavyRainButton;
    

    private bool _debugMode = false;

    private Button activeButton;
     private void OnEnable()
     {
         activeButton = null;
         var root = GetComponent<UIDocument>().rootVisualElement;

        sunButton = root.Q<Button>("SunButton");
        windButton = root.Q<Button>("WindButton");
        thunderButton = root.Q<Button>("ThunderButton");
        snowButton = root.Q<Button>("SnowButton");
        rainButton = root.Q<Button>("RainButton");
        blizzButton = root.Q<Button>("BlizzardButton");
        cloudButton = root.Q<Button>("CloudButton");
        heavyRainButton = root.Q<Button>("HeavyRainButton");

        windButton.clicked += () => WeatherButtonClicked(windButton, controller.windObject);
        sunButton.clicked += () => WeatherButtonClicked(sunButton, controller.sunObject);
        thunderButton.clicked += () => WeatherButtonClicked(thunderButton, controller.thunderObject);
        snowButton.clicked += () => WeatherButtonClicked(snowButton, controller.snowObject);
        rainButton.clicked += () => WeatherButtonClicked(rainButton, controller.rainObject);
        blizzButton.clicked += () => WeatherButtonClicked(blizzButton, controller.blizzardObject);
        cloudButton.clicked += () => WeatherButtonClicked(cloudButton, controller.cloudObject);
        heavyRainButton.clicked += () => WeatherButtonClicked(heavyRainButton, controller.heavyRainObject);
        

     }

     private void SetActiveButton(Button btn)
     {
         SetInactiveButton();
         activeButton = btn;
         btn.style.color = new StyleColor(Color.black);
         btn.style.backgroundColor = new StyleColor(Color.white);
     }

     private void SetInactiveButton()
     {
         if (activeButton != null)
         {
             activeButton.style.color = new StyleColor(Color.white);
             activeButton.style.backgroundColor = new StyleColor(Color.black);
             activeButton = null;
         }
     }

     private void WeatherButtonClicked(Button btn, GameObject obj)
     {
         controller.ToggleObject(obj);
         if (btn == activeButton)
         {
             SetInactiveButton();
         }
         else
         {
             SetActiveButton(btn);
         }
     }
     
}
