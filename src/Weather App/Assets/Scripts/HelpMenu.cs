using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class HelpMenu : MonoBehaviour
    {
        private Button _closeButton;

        private void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            _closeButton = root.Q<Button>("BackButton");
            _closeButton.clicked += () => CloseModal();
        }

        private void CloseModal()
        {
            print("clicked");
            gameObject.SetActive(false);
        }
    }
}