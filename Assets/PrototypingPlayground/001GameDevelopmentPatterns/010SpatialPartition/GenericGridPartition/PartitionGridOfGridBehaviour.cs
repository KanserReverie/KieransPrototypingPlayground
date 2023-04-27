using UnityEngine;
using UnityEngine.Serialization;

namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.GenericGridPartition
{
    /// <summary>
    /// This will spawn and keep track of a Grid of Grids Partition Behaviours.
    /// </summary>
    /// <typeparam name="T">This is the type of component that you will be spawning and tracking.</typeparam>

    public class PartitionGridOfGridBehaviour<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private int gridsLengthCount = 3;
        [SerializeField] private int gridsWidthCount = 3;
        [SerializeField] private int gridsHeightCount = 3;
        [SerializeField] private int gridsLengthDistanceApart = 10;
        [SerializeField] private int gridsWidthDistanceApart = 10;
        [SerializeField] private int gridsHeightDistanceApart = 10;

        public PartitionGridBehaviour<T> partitionGridBehaviour;

        private void Start()
        {
            for (int length = 0; length < gridsLengthCount; length++)
            {
                Vector3 spawnLocation = transform.position + (Vector3.right * length * gridsLengthDistanceApart); 
                Instantiate(partitionGridBehaviour.gameObject, spawnLocation, transform.rotation, transform);
                // for (int width = 0; width < gridsWidthCount; width++)
                // {
                //     spawnLocation += (Vector3.forward * gridsWidthDistanceApart * width);
                //     Instantiate(partitionGridBehaviour.gameObject, spawnLocation, transform.rotation, transform);
                //     
                //     for (int height = 0; height < gridsHeightCount; height++)
                //     {
                //         spawnLocation += (gridsHeightDistanceApart * height * Vector3.up);
                //         Instantiate(partitionGridBehaviour.gameObject, spawnLocation, transform.rotation, transform);
                //     }
                // }
            }
        }
    }
}