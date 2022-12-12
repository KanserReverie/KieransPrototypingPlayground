using System;
using UnityEngine;

namespace PrototypingPlayground._004QuickPrototypes.OnEnableTiming.Scripts
{
    public class OnEnableTest : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log($"{gameObject.name} - Start Function Run: \n Start is called before the first frame update.");
        }

        // This function is called when the object becomes enabled and active.
        private void OnEnable()
        {
            Debug.Log($"{gameObject.name} - OnEnable Function Run:\n This function is called when the object becomes enabled and active.");
        }
        
        // This function is called when the behaviour becomes disabled.
        private void OnDisable()
        {
            Debug.Log($"{gameObject.name} - OnDisable Function Run:\n This function is called when the behaviour becomes disabled.");
        }
    }
}
