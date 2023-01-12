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
        [SerializeField] private int numberOfBlocksBehindPlayer = 6;
        [SerializeField] private int numberOfBlocksInFrontOfPlayer = 100;
        [Header("Individual Track")]
        [SerializeField] private Section [] sections;
        private Stack<Section> sectionsToLoad;
        private Section currentSectionLoadingRows;
        private Queue<Section> sectionsToDespawn;
        private Section currentSectionToDespawn;
        private Vector3 sectionSpawnPosition;
        private GameObject thisTrack;

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
            
            AttemptToSpawnNextRow();
            AttemptToSpawnNextRow();
            AttemptToSpawnNextRow();
            AttemptToSpawnNextRow();
            
            AttemptToSpawnNextRow();
        }

        private void InitTrack()
        {
            thisTrack = new GameObject("Track");
            sectionSpawnPosition = GetFirstSpawnPosition();
            InitializeSectionsStack();
            AddAllSectionsToStack();
            InitializeSectionsQueue();
            PopNextLoadSection();
            DequeueNextDespawnSection();
        }

        private Vector3 GetFirstSpawnPosition()
        {
            Vector3 spawnPosition = thisTrack.transform.position;
            spawnPosition.z -= (numberOfBlocksBehindPlayer + 1) * Section.ZDistanceBetweenRows; // + 1 as we will spawn blocks in front of this point.
            return spawnPosition;
        }
        
        private void InitializeSectionsStack() => sectionsToLoad = new Stack<Section>();
        
        private void AddAllSectionsToStack()
        {
            for (int i = 0; i < sections.Length; i++)
            {
                Section newInstantiatedSection = SpawnTrackSection(sections[i]).GetComponentInChildren<Section>();
                newInstantiatedSection.InitSection(newInstantiatedSection.gameObject);
                sectionsToLoad.Push(newInstantiatedSection);
            }
        }
        
        private void InitializeSectionsQueue() => sectionsToDespawn = new Queue<Section>();
        
        private void PopNextLoadSection()
        {
            currentSectionLoadingRows = sectionsToLoad.Pop().GetComponentInChildren<Section>();
            sectionsToDespawn.Enqueue(currentSectionLoadingRows);
        }

        private void DequeueNextDespawnSection()
        {
            currentSectionToDespawn = sectionsToDespawn.Dequeue();
        }


        private void AttemptToSpawnNextRow()
          {
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
                        PopNextLoadSection();
                    }
                    else
                    {
                        canSpawnRow = false;
                    }
                }

            } while (canSpawnRow);

            Debug.LogWarning("Sorry, no more rows to spawn.");
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