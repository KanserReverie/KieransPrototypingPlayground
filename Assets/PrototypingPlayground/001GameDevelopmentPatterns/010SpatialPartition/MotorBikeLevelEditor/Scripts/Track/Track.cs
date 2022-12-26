using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.MotorBikeLevelEditor.Track
{
    /// <summary>
    /// A track is made from many sections.
    /// </summary>
    public class Track : MonoBehaviour
    {
        [SerializeField] private Section preTrackSection; // This will be spawned behind the player at start so the camera doesn't see nothingness behind the player
        [SerializeField] private Section[] sections;

        private void Awake()
        {
            AssetWholeTrackIsNotNull();
        }
        private void AssetWholeTrackIsNotNull()
        {
            AssertPreTrackSectionIsNotNull();
            AssetSectionsAreNotNull();
        }

        private void AssetSectionsAreNotNull()
        {
            Assert.IsTrue(sections.Length > 0);
            
            foreach (Section segmentOfTrack in sections)
            {
                Assert.IsNotNull(segmentOfTrack);
                segmentOfTrack.AssertRowsAreNotNull();
            }
        }
        
        private void AssertPreTrackSectionIsNotNull()
        {
            Assert.IsNotNull(preTrackSection);
            preTrackSection.AssertRowsAreNotNull();
        }

        public void Start()
        {
            SpawnPreTrackSection();
            // todo: Spawn each section of track
        }
        private void SpawnPreTrackSection()
        {
            // Find how far back we need to spawn the track.
            float firstSectionZSpawnPosition = transform.position.z - (Section.ZDistanceBetweenRows * preTrackSection.NumberOfRows);
            // Get the exact Vector 3 of this spawn based on position.
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, firstSectionZSpawnPosition);
            // Instantiate the Track at the above Spawn Point.
            Instantiate(preTrackSection, spawnPosition, transform.rotation, this.gameObject.transform);
        }
    }
}