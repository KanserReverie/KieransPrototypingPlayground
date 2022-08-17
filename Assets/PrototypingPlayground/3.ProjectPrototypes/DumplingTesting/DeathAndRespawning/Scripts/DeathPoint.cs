using UnityEngine;
namespace PrototypingPlayground._3.ProjectPrototypes.DumplingTesting.DeathAndRespawning.Scripts
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
