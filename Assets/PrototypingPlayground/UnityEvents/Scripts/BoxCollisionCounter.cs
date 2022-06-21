using System;
using TMPro;
using UnityEngine;
namespace PrototypingPlayground.UnityEvents.Scripts
{
    public class BoxCollisionCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text boxCounterTMPText;
        
        private int _boxCounter;
        
        private void Start()
        {
            _boxCounter = 0;
            boxCounterTMPText.text = $"Count = {_boxCounter}";
        }
        
        public void AddOneToBoxCounter()
        {
            _boxCounter++;
            boxCounterTMPText.text = $"Count = {_boxCounter}";
        }
    }
}
