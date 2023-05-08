using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground.UsefulScripts
{
    /// <summary>
    /// This will make it so the attached slider returns its original value on start.
    /// </summary>
    public class SetSliderInStart : MonoBehaviour
    {
        private void Start()
        {
            
            Slider slider = this.GetComponent<Slider>();

            float originalValue = slider.value;

            slider.value = slider.maxValue;
            slider.value = slider.minValue;

            slider.value = originalValue;
        }
    }
}