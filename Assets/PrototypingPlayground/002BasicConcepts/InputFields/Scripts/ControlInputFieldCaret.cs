using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class ControlInputFieldCaret : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputFieldToChange;

        public int speedBPS = 8;
        public Color colourCaret = Color.red;
        public Color colourSelection = Color.red;
        
        void Start()
        {
            if (inputFieldToChange)
            {
                inputFieldToChange.caretBlinkRate = speedBPS;
                inputFieldToChange.caretColor = Color.red;
                inputFieldToChange.selectionColor = Color.red;
            }
        }
    }
}
