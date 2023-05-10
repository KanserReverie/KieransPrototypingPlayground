using System.Collections;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
// ReSharper disable All
namespace PrototypingPlayground._002BasicConcepts.Properties
{
    public class PropertiesExample : MonoBehaviour
    {
        public float variable;
        
        [field: SerializeField] public float AutoProperty { get; private set; }
        
        [SerializeField] private float normalProperty = 50f;
        public float NormalProperty
        {
            get => normalProperty;
            set
            {
                if (value > 100)
                    value = 100;

                if (value < 0)
                    value = 0;

                normalProperty = value;

                Debug.Log($"NormalProperty = {NormalProperty}");

                if (value == 0)
                {
                    CommonlyUsedStaticMethods.QuitGame();
                }
            }
        }
        public float NormalPropertySetting { get; set; } = 100f;

        public void PlayNormalPropertyExample()
        {
            StartCoroutine(NormalPropertyExample());
        }
        private IEnumerator NormalPropertyExample()
        {
            Debug.Log($"In our 'setter' we have said NormalProperty CANNOT: \n 1) Go above '100' 2) If it goes below '0' the game will Quit");
            yield return new WaitForSeconds(5f);
            Debug.Log($"Set NormalProperty to 100");
            yield return new WaitForSeconds(1f);
            NormalProperty = 100;
            yield return new WaitForSeconds(3f);
            Debug.Log($"Add 20 to NormalProperty");
            yield return new WaitForSeconds(1f);
            NormalProperty += 20;
            yield return new WaitForSeconds(3f);
            Debug.Log($"Subtract 150 from NormalProperty");
            yield return new WaitForSeconds(1f);
            NormalProperty -= 150;
        }
    }
}
