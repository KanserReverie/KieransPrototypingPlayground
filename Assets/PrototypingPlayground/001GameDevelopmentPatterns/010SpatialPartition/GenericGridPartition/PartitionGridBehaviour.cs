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
            for (int length = 0; length <= gridLengthCount; length++)
            {
                Vector3 spawnLocation = transform.position + (Vector3.right * length * gridLengthDistanceApart); 
                //Instantiate(partitionBehaviour.gameObject, spawnLocation, transform.rotation, transform);
                for (int width = 0; width <= gridWidthCount; width++)
                {
                    spawnLocation += (Vector3.forward * gridWidthDistanceApart * width);
                    Instantiate(partitionBehaviour.gameObject, spawnLocation, transform.rotation, transform);
                    //     
                    //     for (int height = 0; height < gridHeightCount; height++)
                    //     {
                    //         spawnLocation += (gridHeightDistanceApart * height * Vector3.up);
                    //         Instantiate(partitionBehaviour.gameObject, spawnLocation, transform.rotation, transform);
                    //     }
                }
            }
        }
    }
}