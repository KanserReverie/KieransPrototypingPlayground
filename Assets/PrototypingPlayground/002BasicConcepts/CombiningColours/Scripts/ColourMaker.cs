using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.CombiningColours.Scripts
{
    public class ColourMaker : MonoBehaviour
    {
        public Color finalColour;
        [SerializeField] private Image colourMadeDisplayImage;
        private float redValue;
        private float greenValue;
        private float blueValue;
        private float alphaValue;

        private void Awake()
        {
            Assert.IsNotNull(colourMadeDisplayImage);
        }

        private void Update()
        {
            finalColour = new Color(redValue, greenValue, blueValue, alphaValue);
            colourMadeDisplayImage.color = finalColour;
        }

        public void UpdateRed(float _newRedValue)
        {
            redValue = _newRedValue;
        }
        
        public void UpdateBlue(float _newBlueValue)
        {
            blueValue = _newBlueValue;
        }
        public void UpdateGreen(float _newGreenValue)
        {
            greenValue = _newGreenValue;
        }
        public void UpdateAlpha(float _newAlphaValue)
        {
            alphaValue = _newAlphaValue;
        }
    }
}