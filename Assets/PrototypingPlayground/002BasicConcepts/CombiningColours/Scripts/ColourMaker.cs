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

        public void UpdateRed(float newRedValue)
        {
            redValue = newRedValue;
        }
        
        public void UpdateBlue(float newBlueValue)
        {
            blueValue = newBlueValue;
        }
        public void UpdateGreen(float newGreenValue)
        {
            greenValue = newGreenValue;
        }
        public void UpdateAlpha(float newAlphaValue)
        {
            alphaValue = newAlphaValue;
        }
    }
}