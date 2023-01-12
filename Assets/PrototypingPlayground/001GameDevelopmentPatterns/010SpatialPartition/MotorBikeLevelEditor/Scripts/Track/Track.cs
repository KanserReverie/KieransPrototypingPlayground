using System.Collections.Generic;
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
        [SerializeField] private int numberOfBlocksBehindPlayer = 3;
        [SerializeField] private int numberOfBlocksInFrontOfPlayer = 10;
        [Header("Individual Track")]
        [SerializeField] private Section [] sections;

        private Queue<Section> sectionsToLoad;
        private Section currentSectionLoadingRows;
        
        private Stack<Section> sectionsToDespawn;
        private Section currentSectionToDespawn;
        private Vector3 sectionSpawnPosition;
        private GameObject thisTrack;
        private bool fullTrackSpawned;

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
            InitTrack();
            int numberOfBlocksToSpawn = numberOfBlocksBehindPlayer + numberOfBlocksInFrontOfPlayer;

            for (int i = 0; i < numberOfBlocksToSpawn; i++)
            {
                AttemptToSpawnNextRow();
            }
        }

        private void InitTrack()
        {
            fullTrackSpawned = false;
            thisTrack = new GameObject("Track");
            sectionSpawnPosition = GetFirstSpawnPosition();
            InitializeSectionsStack();
            AddAllSectionsToStack();
            InitializeSectionsQueue();
            GetNextLoadSection();
            GetNextDespawnSection();
        }

        private Vector3 GetFirstSpawnPosition()
        {
            Vector3 spawnPosition = thisTrack.transform.position;
            spawnPosition.z -= (numberOfBlocksBehindPlayer) * Section.ZDistanceBetweenRows;
            return spawnPosition;
        }
        
        private void InitializeSectionsStack() => sectionsToLoad = new Queue<Section>();
        
        private void AddAllSectionsToStack()
        {
            for (int i = 0; i < sections.Length; i++)
            {
                Section newInstantiatedSection = SpawnTrackSection(sections[i]).GetComponentInChildren<Section>();
                newInstantiatedSection.InitSection(newInstantiatedSection.gameObject);
                sectionsToLoad.Enqueue(newInstantiatedSection);
            }
        }
        
        private void InitializeSectionsQueue() => sectionsToDespawn = new Stack<Section>();
        
        private void GetNextLoadSection()
        {
            currentSectionLoadingRows = sectionsToLoad.Dequeue().GetComponentInChildren<Section>();
            sectionsToDespawn.Push(currentSectionLoadingRows);
        }

        private void GetNextDespawnSection()
        {
            currentSectionToDespawn = sectionsToDespawn.Pop();
        }

        private void AttemptToSpawnNextRow()
        {
            if (fullTrackSpawned) return;
            
            bool canSpawnRow = true;
            do
            {
                if (currentSectionLoadingRows.AreThereRowsToSpawn())
                {
                    currentSectionLoadingRows.AttemptToSpawnNextRow();
                    return;
                }
                else
                {
                    if (AreThereAnyMoreSectionsToSpawn())
                    {
                        GetNextLoadSection();
                    }
                    else
                    {
                        canSpawnRow = false;
                    }
                }

            } while (canSpawnRow);

            Debug.LogWarning("Spawned the full track.");
            fullTrackSpawned = true;
        }

        private bool AreThereAnyMoreSectionsToSpawn() => sectionsToLoad.Count > 0;

        private Section SpawnTrackSection(Section _section)
        {
            Section spawnedSectionGameObject = InstantiateSection(_section);
            _section.InitSection(spawnedSectionGameObject.gameObject);
            GetNextSpawnPosition(_section);
            return spawnedSectionGameObject;
        }
        
        private Section InstantiateSection(Section _section)
        {
            GameObject newSpawnedTrack = Instantiate(_section.gameObject, sectionSpawnPosition, thisTrack.transform.rotation, thisTrack.transform);
            return newSpawnedTrack.GetComponentInChildren<Section>();
        }
        
        private void GetNextSpawnPosition(Section _section)
        {
            sectionSpawnPosition.z += _section.RowsInSection * Section.ZDistanceBetweenRows;
        }
    }
}