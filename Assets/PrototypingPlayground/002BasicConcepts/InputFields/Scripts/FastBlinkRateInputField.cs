using TMPro;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class FastBlinkRateInputField : MonoBehaviour
    {
        public TMP_InputField inputFieldToChangeBlinkRate;
        void Start()
        {
            inputFieldToChangeBlinkRate.caretBlinkRate = 5f;
        }
    }
}
