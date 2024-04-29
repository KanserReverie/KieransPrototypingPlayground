using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class ChangeFocus : MonoBehaviour
    {
        public TMP_InputField inputField1;
        public TMP_InputField inputField2;

        public Button focusInputField1;
        public Button focusInputField2;

        private void Start()
        {
            focusInputField1.onClick.AddListener(ChangeFocusOfInputField1);
            focusInputField2.onClick.AddListener(ChangeFocusOfInputField2);
        }

        private void ChangeFocusOfInputField1()
        {
            inputField1.Select();
        }

        private void ChangeFocusOfInputField2()
        {
            inputField2.Select();
        }
    }
}