using UnityEngine;
namespace PrototypingPlayground._2.BasicConcepts.UnityActions.Scripts
{
    public class ActionReceiver : MonoBehaviour
    {
        private int _currentMaterialIndex;
        [SerializeField] private Material[] cubeMaterialsToChangeTo;

        private void Start()
        {
            _currentMaterialIndex = 0;  
            gameObject.GetComponent<Renderer>().material = cubeMaterialsToChangeTo[_currentMaterialIndex];
        }
        
        public void ChangeCubeColor()
        {
            _currentMaterialIndex++;
            if (_currentMaterialIndex >= cubeMaterialsToChangeTo.Length)
                _currentMaterialIndex = 0;
            gameObject.GetComponent<Renderer>().material = cubeMaterialsToChangeTo[_currentMaterialIndex];
            Debug.Log("Next Colour!");
        }
    }
}
