using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.CombiningColours.Scripts
{
    public class ColourMaker : MonoBehaviour
    {
        [SerializeField] private Image colourMade;
        [SerializeField] private float redValue;
        [SerializeField] private float greenValue;
        [SerializeField] private float blueValue;
        [SerializeField] private float alphaValue;

        private void Awake()
        {
            Assert.IsNotNull(colourMade);
        }

        private void Update()
        {
            colourMade.color = new Color(redValue, greenValue, blueValue, alphaValue);
            Debug.Log($"New Colour = {new Color(redValue, greenValue, blueValue, alphaValue)}");
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