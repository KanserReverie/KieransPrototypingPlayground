using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.GenericGridPartition
{
    /// <summary>
    /// This will spawn and keep track of a grid of Partition Behaviours.
    /// </summary>
    /// <typeparam name="T">This is the type of component that you will be spawning and tracking.</typeparam>
    public class PartitionGridBehaviour<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private int gridLengthCount = 3;
        [SerializeField] private int gridWidthCount = 3;
        [SerializeField] private int gridHeightCount = 3;
        [SerializeField] private int gridLengthDistanceApart = 2;
        [SerializeField] private int gridWidthDistanceApart = 2;
        [SerializeField] private int gridHeightDistanceApart = 2;
 
        public PartitionBehaviour<T> partitionBehaviour;

        private void Start()
        {
            SpawnPartitionBehaviours();
        }

        private void SpawnPartitionBehaviours()
        {
            for (int length = 0; length < gridLengthCount; length++)
            {
                Vector3 spawnLocation = transform.position + (Vector3.right * gridLengthDistanceApart * length); 
                for (int width = 0; width < gridWidthCount; width++)
                {
                    Vector3 spawnWidthLocation = spawnLocation + (Vector3.forward * gridWidthDistanceApart * width);
                    for (int height = 0; height < gridHeightCount; height++)
                    {
                        Vector3 spawnHeightLocation = spawnWidthLocation + (gridHeightDistanceApart * Vector3.up * height);
                        Instantiate(partitionBehaviour.gameObject, spawnHeightLocation, transform.rotation, transform);
                    }
                }
            }
        }
    }
}