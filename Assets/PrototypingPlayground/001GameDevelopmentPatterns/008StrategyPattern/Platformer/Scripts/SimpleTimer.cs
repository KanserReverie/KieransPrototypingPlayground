using TMPro;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.Platformer
{
    public class SimpleTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text textMeshProUGUI;
        private float timer;

        private void Start()
        {
            timer = 0;
            textMeshProUGUI.text = $"{timer}";
        }

        private void Update()
        {
            timer += Time.deltaTime;
            textMeshProUGUI.text = $"{timer}";
        }
    }
}
