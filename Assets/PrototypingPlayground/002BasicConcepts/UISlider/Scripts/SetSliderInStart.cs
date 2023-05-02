using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.UISlider
{
    public class SetSliderInStart : MonoBehaviour
    {
        private void Start()
        {
            // This will make it so the attached slider returns its original value on start.
            
            Slider slider = this.GetComponent<Slider>();

            float originalValue = slider.value;

            slider.value = slider.maxValue;
            slider.value = slider.minValue;

            slider.value = originalValue;
        }
    }
}