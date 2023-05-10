using TMPro;
using UnityEngine;
namespace PrototypingPlayground._002BasicConcepts.UnityEvents
{
    public class BoxCollisionCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text boxCounterTMPText;
        
        private int boxCounter;
        
        private void Start()
        {
            boxCounter = 0;
            boxCounterTMPText.text = $"Count = {boxCounter}";
        }
        
        public void AddOneToBoxCounter()
        {
            boxCounter++;
            boxCounterTMPText.text = $"Count = {boxCounter}";
        }
    }
}
