using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.InputFields.Day1
{
    public class DisplayInputField : MonoBehaviour
    {
        public TMP_InputField inputField;

        public Button displayInputField;
        public Button clearInputField;

        public TextMeshProUGUI displayText;

        private void Start()
        {
            displayInputField.onClick.AddListener(DisplayInputFieldToText);
            clearInputField.onClick.AddListener(ClearInputField);
        }

        private void ClearInputField()
        {
            inputField.text = "";
            DisplayInputFieldToText();
        }

        private void DisplayInputFieldToText()
        {
            displayText.text = inputField.text;
        }
    }
}
