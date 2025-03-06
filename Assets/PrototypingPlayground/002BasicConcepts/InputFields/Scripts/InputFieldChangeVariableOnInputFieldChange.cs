using TMPro;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class InputFieldChangeVariableOnInputFieldChange : MonoBehaviour
    {
        public TMP_InputField inputFieldToChange;

        public string variableString;

        public SimpleStringDataHolder simpleStringDataHolder;

        private void Start()
        {
            if (inputFieldToChange)
            {
                inputFieldToChange.onValueChanged.AddListener(OnInputValueChanged);
            }
        }

        private void OnInputValueChanged(string inputFieldString)
        {
            variableString = inputFieldString;
            if (simpleStringDataHolder)
            {
                simpleStringDataHolder.simpleStringToHold = inputFieldString;
            }
            Debug.Log($"Change String to {variableString}");
        }
    }
}
