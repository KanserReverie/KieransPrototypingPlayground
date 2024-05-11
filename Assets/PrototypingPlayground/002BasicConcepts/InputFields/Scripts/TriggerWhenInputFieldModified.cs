using System;
using TMPro;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class TriggerWhenInputFieldModified : MonoBehaviour
    {
        public TMP_InputField inputField;
        public TMP_Text textField;

        private void Start()
        {
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
            textField.text = "";
        }

        private void OnInputFieldValueChanged(string newValue)
        {
            textField.text += $"\nNew Value = {newValue}";
        }
    }
}
