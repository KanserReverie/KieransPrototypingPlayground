using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.GenericGridPartition
{
    /// <summary>
    /// This will spawn and keep track of a grid of Partition Behaviours.
    ///
    /// You can go for inception by dragging in grid of grids into the Partition Behaviour.
    /// See example for more details
    /// </summary>
    /// <typeparam name="T">This is the type of component that you will be spawning and tracking.</typeparam>
    public class PartitionGridBehaviour<T> : PartitionBehaviour<T> where T : Component
    {
        [Header("Partition Grid Behaviour")]
        [SerializeField] protected int gridLengthCount = 3;
        [SerializeField] protected int gridWidthCount = 3;
        [SerializeField] protected int gridHeightCount = 3;
        [SerializeField] protected int gridLengthDistanceApart = 2;
        [SerializeField] protected int gridWidthDistanceApart = 2;
        [SerializeField] protected int gridHeightDistanceApart = 2;

        [SerializeField] protected PartitionBehaviour<T> partitionBehaviour;
        
        /// <summary>
        /// And an individual element at coords (x, y, z) would be accessed like this:
        /// matrixOfPartitionBehaviours[x][y][z].Init();
        /// </summary>
        protected List<List<List<PartitionBehaviour<T>>>> matrixOfPartitionBehaviours = new List<List<List<PartitionBehaviour<T>>>>();

        private void Start()
        {
            SpawnPartitionBehaviours();
        }

        /// <summary>
        /// This will spawn in and save all Partition Behaviours.
        /// </summary>
        private void SpawnPartitionBehaviours()
        {
            for (int width = 0; width < gridWidthCount; width++)
            {
                Vector3 spawnLocation = transform.position + (Vector3.right * gridWidthDistanceApart * width);
                matrixOfPartitionBehaviours.Add(new List<List<PartitionBehaviour<T>>>());
                {
                    for (int height = 0; height < gridHeightCount; height++)
                    {
                        Vector3 spawnHeightLocation = spawnLocation + (gridHeightDistanceApart * Vector3.up * height);
                        matrixOfPartitionBehaviours[width].Add(new List<PartitionBehaviour<T>>());
                        
                        for (int length = 0; length < gridLengthCount; length++)
                        {
                            Vector3 spawnLengthLocation = spawnHeightLocation + (Vector3.forward * gridLengthDistanceApart * length);
                            GameObject spawnedGameObject = Instantiate(partitionBehaviour.gameObject, spawnLengthLocation, transform.rotation, transform);
                            matrixOfPartitionBehaviours[width][height].Add(spawnedGameObject.GetComponent<PartitionBehaviour<T>>());
                            matrixOfPartitionBehaviours[width][height][length].SetPartitionDetails(this, new Vector3(width,height,length));
                        }
                    }
                }
            }
        }
    }
}