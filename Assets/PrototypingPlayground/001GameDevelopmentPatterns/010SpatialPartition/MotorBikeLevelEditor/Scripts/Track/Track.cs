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
        [SerializeField] private Section [] sections;
        private int currentSectionToSpawnIndex;
        private int currentSectionToDespawnIndex;
        private Vector3 sectionSpawnPosition;

        private void Awake()
        {
            AssetWholeTrackIsNotNull();
        }
        private void AssetWholeTrackIsNotNull()
        {
            foreach (Section sectionOfTrack in sections)
            {
                Assert.IsNotNull(sectionOfTrack);
                sectionOfTrack.AssertRowsAreNotNull();
            }
        }

        public void Start()
        {
            int numberOfBlocksToSpawn = numberOfBlocksBehindPlayer + numberOfBlocksInFrontOfPlayer;
            
            sectionSpawnPosition = GetFirstSpawnPosition();
            
            currentSectionToSpawnIndex = 0;
            
            InstantiateTrackSection(sections[currentSectionToSpawnIndex]);
            
            AttemptToSpawnNextRow();
            AttemptToSpawnNextRow();
            
            // todo: Spawn each section of track
        }
        private void AttemptToSpawnNextRow()
        {
            bool canSpawnRow = true;
            
            do
            {
                if (sections[currentSectionToSpawnIndex].AreThereRowsToSpawn())
                {
                    sections[currentSectionToSpawnIndex].AttemptToSpawnNextRow();
                    return;
                }
                
                if (AreThereAnyMoreSectionsToSpawn())
                {
                    GetNextSection();
                } 
                else
                {
                    canSpawnRow = false;
                }
                
            } while (canSpawnRow);
            
            Debug.LogWarning("Sorry, no more rows to spawn.");
        }
        
        private bool AreThereAnyMoreSectionsToSpawn() => currentSectionToSpawnIndex < sections.Length;
        
        private void GetNextSection()
        {
            currentSectionToSpawnIndex++;
        }

        private Vector3 GetFirstSpawnPosition()
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.z -= numberOfBlocksBehindPlayer * Section.ZDistanceBetweenRows;
            return spawnPosition;
        }
        
        private void InstantiateTrackSection(Section _section)
        {
            GameObject spawnedSectionGameObject = InstantiateSection(_section);
            _section.InitSection(spawnedSectionGameObject);
            GetNextSpawnPosition(_section);
        }
        
        private GameObject InstantiateSection(Section _section)
        {
            return Instantiate(_section.gameObject, sectionSpawnPosition, transform.rotation, this.gameObject.transform);
        }
        
        private void GetNextSpawnPosition(Section _section)
        {
            sectionSpawnPosition.z += _section.RowsInSection * Section.ZDistanceBetweenRows;
        }
    }
}