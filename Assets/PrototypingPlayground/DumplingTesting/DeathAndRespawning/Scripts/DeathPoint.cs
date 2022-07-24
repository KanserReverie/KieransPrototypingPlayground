using UnityEngine;

namespace PrototypingPlayground.DumplingTesting.DeathAndRespawning
{
    public class DeathPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider _other)
        {
            DumplingController dumplingController = _other.gameObject.GetComponent<DumplingController>();
            
            if (dumplingController != null)
            {
                dumplingController.Die();
            }
        }
    }
}
