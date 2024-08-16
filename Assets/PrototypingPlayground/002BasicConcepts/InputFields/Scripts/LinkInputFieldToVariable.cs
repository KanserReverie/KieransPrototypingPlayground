//using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class LinkInputFieldToVariable : MonoBehaviour
    {
        public TMP_InputField inputFieldToModify;
        public string changedString;
        public int changedInt;
        
        void Start()
        {
            inputFieldToModify.contentType = TMP_InputField.ContentType.IntegerNumber;
        }
        
        void Update()
        {
            changedString = inputFieldToModify.text;
            if (changedString != "")
            {
                // NOT WORKING
                //changedInt = changedString.ParseLargeInteger();
                changedInt = 0;
            }
            else
            {
                changedInt = 0;
            }
        }
    }
}
