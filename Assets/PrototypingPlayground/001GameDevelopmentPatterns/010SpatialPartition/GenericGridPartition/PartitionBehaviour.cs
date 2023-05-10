using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.GenericGridPartition
{
    /// <summary>
    /// This will be the item you are making a partition for.
    /// </summary>
    /// <typeparam name="T">This is the type of item held in the partition.</typeparam>
    public class PartitionBehaviour<T> : MonoBehaviour where T : Component
    {
        [Header("Partition Behaviour")]
        // This is original object.
        // Store main details about them here.
        [SerializeField] protected PartitionBehaviour<T> partitionGrid;
        [SerializeField] protected Vector3 partitionCoordinates;

        public void SetPartitionDetails(PartitionBehaviour<T> partitionGrid, Vector3 partitionCoordinates)
        {
            this.partitionGrid = partitionGrid;
            this.partitionCoordinates = partitionCoordinates;
        }
    }
}
