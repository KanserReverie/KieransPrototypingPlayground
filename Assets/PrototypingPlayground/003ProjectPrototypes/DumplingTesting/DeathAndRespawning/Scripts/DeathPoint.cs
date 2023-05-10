using UnityEngine;
namespace PrototypingPlayground._003ProjectPrototypes.DumplingTesting.DeathAndRespawning
{
    public class DeathPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            DumplingController dumplingController = other.gameObject.GetComponent<DumplingController>();
            
            if (dumplingController != null)
            {
                dumplingController.Die();
            }
        }
    }
}
