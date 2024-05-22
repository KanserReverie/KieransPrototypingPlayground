using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class ControlInputFieldCaretBlinkingCoroutine : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        public float blinkDuration = 0.5f;
        
        void Start()
        {
            StartCoroutine(BlinkCaret());
        }

        private IEnumerator BlinkCaret()
        {
            while (true)
            {
                inputField.caretColor = new Color(inputField.caretColor.r, inputField.caretColor.g, inputField.caretColor.b, 1f);
                yield return new WaitForSeconds(blinkDuration);
                inputField.caretColor = new Color(inputField.caretColor.r, inputField.caretColor.g, inputField.caretColor.b, 0f);
                yield return new WaitForSeconds(blinkDuration);
            }
        }
    }
}
