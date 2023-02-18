using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class WelcomePopup : MonoBehaviour
    {
        private Button _closeButton;

        private void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            _closeButton = root.Q<Button>("CloseButton");
            _closeButton.clicked += () => CloseModal();
        }

        private void CloseModal()
        {
            gameObject.SetActive(false);
        }
    }
}