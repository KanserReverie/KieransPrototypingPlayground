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
        public int NumberOfRows => row.Length;

        public void AssertRowsAreNotNull()
        {
            Assert.IsTrue(row.Length > 0);
            
            foreach (Row rowOfBlocks in row)
            {
                Assert.IsNotNull(rowOfBlocks);
                rowOfBlocks.AssertBlocksAreNotNull();
            }
        }

        private void Start()
        {
            InstantiateRowsInSection();
        }
        
        private void InstantiateRowsInSection()
        {
            float firstRowZSpawnPosition = transform.position.z + ZDistanceBetweenRows/2;
            
            for (int i = 0; i < row.Length; i++)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, firstRowZSpawnPosition + (i * ZDistanceBetweenRows));
                Instantiate(row[i], spawnPosition, transform.rotation, this.gameObject.transform);
            }
        }
    }
}