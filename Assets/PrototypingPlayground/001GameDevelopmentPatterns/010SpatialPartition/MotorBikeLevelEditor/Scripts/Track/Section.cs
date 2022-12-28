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
        private GameObject thisSectionGameObject;
        private Stack<GameObject> rowsToLoad;
        private Queue<GameObject> rowsToDespawn;

        public bool AreThereRowsToSpawn()
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

        public void InitSection(GameObject _thisGameObject)
        {
            thisSectionGameObject = _thisGameObject;
            InitializeStack();
            AddAllRowsToStack();
            InitializeQueue();
        }
        
        private void InitializeStack() => rowsToLoad = new Stack<GameObject>();
        private void AddAllRowsToStack()
        {
            for (int i = 0; i < row.Length; i++)
            {
                Row newRowToSpawn = row[i];
                GameObject newRowToSpawnGameObject = newRowToSpawn.gameObject;
                rowsToLoad.Push(newRowToSpawnGameObject);
            }
        }
        private void InitializeQueue() => rowsToDespawn = new Queue<GameObject>();

        public void AttemptToSpawnNextRow()
        {
            if (AreThereRowsToSpawn())
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
            Vector3 position = thisSectionGameObject.transform.position;

            float rowZSpawnPosition = position.z + (ZDistanceBetweenRows * rowsToDespawn.Count);
            
            Vector3 rowSpawnPosition = new Vector3(position.x, position.y, rowZSpawnPosition);
            
            return Instantiate(_row, rowSpawnPosition, thisSectionGameObject.transform.rotation, thisSectionGameObject.transform);
        }

        public void DespawnLastRow()
        {
            
        }
    }
}