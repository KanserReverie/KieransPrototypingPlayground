using UnityEngine;

namespace PrototypingPlayground.QuickPrototypes.ControllerMainMenu
{
    public class RotatingCube : MonoBehaviour
    {
        private Rigidbody rb;
        private float xvalue, yvalue;
        private Vector3 spin = new Vector3(4, 5, 0);
    
        private void Start()
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }

        void FixedUpdate()
        {
            rb.AddTorque(spin);
        }
    }
}
