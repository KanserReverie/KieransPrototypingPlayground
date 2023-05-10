using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.UISlider
{
    public class ParticleSystemColour : MonoBehaviour
    {
        [SerializeField] private Color colour1 = Color.green;
        [SerializeField] private Color colour2 = Color.red;

        private Color currentColour;
        private ParticleSystem attachedParticleSystem;

        private void Start()
        {
            attachedParticleSystem = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            ParticleSystem.MainModule particleSystemMainModule = attachedParticleSystem.main;
            particleSystemMainModule.startColor = currentColour;
        }

        public void ChangeColour(float lerpValue)
        {
            currentColour = Color.Lerp(colour1, colour2, lerpValue);
        }
    }
}