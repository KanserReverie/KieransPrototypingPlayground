using TMPro;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class AutocorrectedInputField : MonoBehaviour
    {
        public TMP_InputField inputFieldToAutoCorrect;
        void Start()
        {
            inputFieldToAutoCorrect.contentType = TMP_InputField.ContentType.Autocorrected;
        }
    }
}
