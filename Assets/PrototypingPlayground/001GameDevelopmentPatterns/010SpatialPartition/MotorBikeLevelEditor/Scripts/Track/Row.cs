using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.MotorBikeLevelEditor.Track
{
    /// <summary>
    /// A row is made of 3 blocks next to each other.
    /// </summary>
    public class Row : MonoBehaviour
    {
        [SerializeField] private GameObject [] blocksTopToBottom = new GameObject[3];

        private const float X_DISTANCE_BETWEEN_BLOCKS = 1.0f;

        public void AssertBlocksAreNotNull()
        {
            // If this is not true, consider looking at if anything needs to be changed in the code, as this was built for a 3 lane game.
            Assert.IsTrue(blocksTopToBottom.Length == 3);
            
            foreach (GameObject placeableBlock in blocksTopToBottom)
            {
                Assert.IsNotNull(placeableBlock);
            }
        }

        private void Start()
        {
            InstantiateBlocksInRow();
        }

        private void InstantiateBlocksInRow()
        {
            float firstBlockXSpawnPosition = (-blocksTopToBottom.Length + 1) * (X_DISTANCE_BETWEEN_BLOCKS / 2);

            for (int i = 0; i < blocksTopToBottom.Length; i++)
            {
                Vector3 spawnPosition = new Vector3(firstBlockXSpawnPosition + (i * X_DISTANCE_BETWEEN_BLOCKS), transform.position.y, transform.position.z);
                Instantiate(blocksTopToBottom[i], spawnPosition, transform.rotation, transform);
            }
        }
    }
}