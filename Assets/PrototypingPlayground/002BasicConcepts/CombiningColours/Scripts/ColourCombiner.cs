using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.CombiningColours.Scripts
{
    public class ColourCombiner : MonoBehaviour
    {
        [SerializeField] private ColourMaker colourMaker1;
        [SerializeField] private ColourMaker colourMaker2;
        [SerializeField] private Image additiveColourDisplayImage;
        [SerializeField] private Image multiplicativeColourDisplayImage;
        [SerializeField] private Image addAndDivideByTwoColourDisplayImage;
        [SerializeField] private Image timesAndDivideByTwoColourDisplayImage;

        private void Awake()
        {
            Assert.IsNotNull(colourMaker1);
            Assert.IsNotNull(colourMaker2);
            Assert.IsNotNull(additiveColourDisplayImage);
            Assert.IsNotNull(multiplicativeColourDisplayImage);
            Assert.IsNotNull(addAndDivideByTwoColourDisplayImage);
            Assert.IsNotNull(timesAndDivideByTwoColourDisplayImage);
        }
        
        private void Update()
        {
            additiveColourDisplayImage.color = colourMaker1.finalColour + colourMaker2.finalColour;
            multiplicativeColourDisplayImage.color = colourMaker1.finalColour * colourMaker2.finalColour;
            addAndDivideByTwoColourDisplayImage.color = (colourMaker1.finalColour + colourMaker2.finalColour)/2;
            timesAndDivideByTwoColourDisplayImage.color = (colourMaker1.finalColour * colourMaker2.finalColour)/2;
        }
    }
}
