using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.MotorBikeLevelEditor.Track
{
    /// <summary>
    /// A section is made from rows of blocks.
    /// </summary>
    public class Section : MonoBehaviour
    {
        [SerializeField] private Row[] row;
        private const float Z_DISTANCE_BETWEEN_ROWS = 1.0f;
        public static float ZDistanceBetweenRows => Z_DISTANCE_BETWEEN_ROWS;
        public int RowsInSection => row.Length;
        private Stack<GameObject> rowsToLoad;
        private Queue<GameObject> rowsToDespawn;

        public bool AnyMoreSectionsToSpawn()
        {
            return rowsToLoad.Count > 0;
        }

        public bool AnyMoreSectionsToDespawn()
        {
            return rowsToDespawn.Count > 0;
        }

        public void AssertRowsAreNotNull()
        {
            Assert.IsTrue(row.Length > 0);
            
            foreach (Row rowOfBlocks in row)
            {
                Assert.IsNotNull(rowOfBlocks);
                rowOfBlocks.AssertBlocksAreNotNull();
            }
        }

        public void InitSection()
        {
            Debug.Log("Track Initialised");
            AddAllRowsToRowsToLoadStack();
        }
        
        private void AddAllRowsToRowsToLoadStack()
        {
            for (int i = 0; i < row.Length; i++)
            {
                Debug.Log($"row.Length = {row.Length} || i = {i}");
                rowsToLoad.Push(row[i].gameObject);
            }
        }

        /// <summary>
        /// This will:
        ///     1. Pop the next row and spawn it.
        ///     2. Add the spawned row to the despawn Queue. 
        /// </summary>
        public void SpawnNextRow()
        {
            if (AnyMoreSectionsToSpawn())
            {
                GameObject spawnedRow = InstantiateRow(rowsToLoad.Pop());
                rowsToDespawn.Enqueue(spawnedRow);
            }
            else
            {
                Debug.LogWarning("Sorry, no more rows to spawn.");
            }
        }
        
        private GameObject InstantiateRow(GameObject _row)
        {
            float rowZSpawnPosition = transform.position.z + (ZDistanceBetweenRows * rowsToDespawn.Count);
            Vector3 rowSpawnPosition = new Vector3(transform.position.x, transform.position.y, rowZSpawnPosition);
            return Instantiate(_row, rowSpawnPosition, transform.rotation, this.gameObject.transform);
        }

        public void DespawnLastRow()
        {
            
        }
    }
}