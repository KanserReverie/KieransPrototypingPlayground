using UnityEngine;
namespace PrototypingPlayground._002BasicConcepts.UnityActions
{
    public class ActionReceiver : MonoBehaviour
    {
        private int currentMaterialIndex;
        [SerializeField] private Material[] cubeMaterialsToChangeTo;

        private void Start()
        {
            currentMaterialIndex = 0;  
            gameObject.GetComponent<Renderer>().material = cubeMaterialsToChangeTo[currentMaterialIndex];
        }
        
        public void ChangeCubeColor()
        {
            currentMaterialIndex++;
            if (currentMaterialIndex >= cubeMaterialsToChangeTo.Length)
                currentMaterialIndex = 0;
            gameObject.GetComponent<Renderer>().material = cubeMaterialsToChangeTo[currentMaterialIndex];
            Debug.Log("Next Colour!");
        }
    }
}
