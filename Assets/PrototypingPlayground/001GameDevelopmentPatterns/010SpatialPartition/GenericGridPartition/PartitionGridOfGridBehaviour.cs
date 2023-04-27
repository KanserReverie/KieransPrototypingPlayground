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
            SpawnPartitionGridOfGridBehaviours();
        }

        private void SpawnPartitionGridOfGridBehaviours()
        {
            for (int length = 0; length < gridsLengthCount; length++)
            {
                Vector3 spawnLocation = transform.position + (Vector3.right * gridsLengthDistanceApart * length); 
                for (int width = 0; width < gridsWidthCount; width++)
                {
                    Vector3 spawnWidthLocation = spawnLocation + (Vector3.forward * gridsWidthDistanceApart * width);
                    for (int height = 0; height < gridsHeightCount; height++)
                    {
                        Vector3 spawnHeightLocation = spawnWidthLocation + (gridsHeightDistanceApart * Vector3.up * height);
                        Instantiate(partitionGridBehaviour.gameObject, spawnHeightLocation, transform.rotation, transform);
                    }
                }
            }
        }
    }
}