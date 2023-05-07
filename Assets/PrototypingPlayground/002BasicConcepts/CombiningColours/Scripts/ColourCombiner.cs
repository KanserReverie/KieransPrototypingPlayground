using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace PrototypingPlayground._002BasicConcepts.CombiningColours.Scripts
{
    public class ColourCombiner : MonoBehaviour
    {
        [SerializeField] private ColourMaker colourMaker1;
        [SerializeField] private ColourMaker colourMaker2;

        private void Awake()
        {
            Assert.IsNotNull(colourMaker1);
            Assert.IsNotNull(colourMaker2);
        }

        void Start()
        {
            
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
