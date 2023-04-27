using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.GenericGridPartition
{
    /// <summary>
    /// This will be the item you are making a partition for.
    /// </summary>
    /// <typeparam name="T">This is the type of item held in the partition.</typeparam>
    public class PartitionBehaviour<T> : MonoBehaviour where T : Component
    {
        // DEBUGGING, DELETE IF NEED BE!
        private void Start()
        {
            Debug.Log($"This is a partition item of type {typeof(T).ToString()}");
        }
    }
}
