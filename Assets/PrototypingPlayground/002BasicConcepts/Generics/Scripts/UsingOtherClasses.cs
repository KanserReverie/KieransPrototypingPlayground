using TMPro;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.Generics.Scripts
{
    public class UsingOtherClasses : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI callCountText;
        private SampleGenericImplementations<UsingOtherClasses> genericExampleClass;

        private void Start()
        {
            genericExampleClass = new SampleGenericImplementations<UsingOtherClasses>();
        }

        private void Update()
        {
            callCountText.text = genericExampleClass.OutputCount.ToString();
        }

        public void CallMethod()
        {
            genericExampleClass.OutputAnyType(this);
        }
    }
}