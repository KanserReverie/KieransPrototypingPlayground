using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.MotorBikeLevelEditor.Track
{
    /// <summary>
    /// A track is made from many sections.
    /// </summary>
    public class Track : MonoBehaviour
    {
        [Header("Track Settings")]
        [SerializeField] private int numberOfBlocksBehindPlayer = 6;
        [SerializeField] private int numberOfBlocksInFrontOfPlayer = 100;
        [Header("Individual Track")]
        [SerializeField] private Section preTrackSection; // This will be spawned behind the player so the camera doesn't see nothingness behind the player.
        [SerializeField] private Section [] sections;
        [SerializeField] private Section endTrackSection; // Once the player touches this the Track Ends.
        private Section currentTrackToSpawn;
        private Section currentTrackToDespawn;
        private Vector3 sectionSpawnPosition;

        private void Awake()
        {
            AssetWholeTrackIsNotNull();
        }
        private void AssetWholeTrackIsNotNull()
        {
            AssertSectionIsNotNull(preTrackSection);
            
            foreach (Section sectionOfTrack in sections)
            {
                AssertSectionIsNotNull(sectionOfTrack);
            }
            
            AssertSectionIsNotNull(endTrackSection);
        }
        private void AssertSectionIsNotNull(Section _section)
        {
            Assert.IsNotNull(_section);
            _section.AssertRowsAreNotNull();
        }

        public void Start()
        {
            int numberOfBlocksToSpawn = numberOfBlocksBehindPlayer + numberOfBlocksInFrontOfPlayer;
            sectionSpawnPosition = GetFirstSpawnPosition();
            InstantiateNextSection(preTrackSection);
            // todo: Spawn each section of track
        }
        
        private Vector3 GetFirstSpawnPosition()
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.z -= numberOfBlocksBehindPlayer * Section.ZDistanceBetweenRows;
            return spawnPosition;
        }
        
        private void InstantiateNextSection(Section _section)
        {
            InstantiateSection(_section);
            _section.InitSection();
            GetNextSpawnPosition(_section);
        }
        
        private void InstantiateSection(Section _section)
        {
            Instantiate(_section, sectionSpawnPosition, transform.rotation, this.gameObject.transform);
        }
        
        private void GetNextSpawnPosition(Section _section)
        {
            sectionSpawnPosition.z += _section.RowsInSection * Section.ZDistanceBetweenRows;
        }
    }
}