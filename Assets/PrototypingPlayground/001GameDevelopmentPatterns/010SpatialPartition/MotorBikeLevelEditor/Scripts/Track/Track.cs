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
        [SerializeField] private int numberOfRowsBehindPlayer = 3;
        [SerializeField] private int numberOfRowsInFrontOfPlayer = 10;
        [Header("Individual Track")]
        [SerializeField] private Section [] sections;

        private Queue<Section> sectionsToLoad;
        private Section currentSectionLoadingRows;
        
        private Queue<Section> sectionsToDespawn;
        private Section currentSectionDespawningRows;
        private Vector3 sectionSpawnPosition;
        private GameObject thisTrack;
        private bool trackCompletelySpawned;
        public bool TrackCompletelySpawned => trackCompletelySpawned;
        private bool trackCompletelyDespawned;
        public bool TrackCompletelyDespawned => trackCompletelyDespawned;

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

            InitialTrackInstantiation();
        }
        private void InitialTrackInstantiation()
        {
            int numberOfRowsToSpawn = CheckHowManyRowsToSpawn();
            for (int i = 0; i < numberOfRowsToSpawn; i++)
            {
                AttemptToSpawnNextRow();
            }
        }
        private int CheckHowManyRowsToSpawn()
        {
            return numberOfRowsBehindPlayer + numberOfRowsInFrontOfPlayer;
        }
        
        public void AttemptToDespawnLastRow()
        {
            if (trackCompletelyDespawned) return;
            bool anyRowsToDespawn = true;

            do
            {
                if (currentSectionDespawningRows.AreThereRowsToDespawn())
                {
                    currentSectionDespawningRows.AttemptToDespawnLastRow();
                    return;
                }
                else
                {
                    if (AreThereAnyMoreSectionsToDespawn())
                    {
                        GetNextDespawnSection();
                    }
                    else
                    {
                        anyRowsToDespawn = false;
                    }
                }
            } while (anyRowsToDespawn);

            if (trackCompletelySpawned)
            {
                Debug.Log("Despawned the full track."); 
                trackCompletelyDespawned = true;
            }
            else
            {
                Debug.Log("Currently no more sections to despawn.");
            }
        }
        
        private void InitTrack()
        {
            trackCompletelySpawned = false;
            thisTrack = new GameObject("Track");
            sectionSpawnPosition = GetFirstSpawnPosition();
            InitializeSpawnSections();
            AddAllSectionsToSpawn();
            InitializeDespawnSections();
            GetNextLoadSection();
            GetNextDespawnSection();
        }

        private Vector3 GetFirstSpawnPosition()
        {
            Vector3 spawnPosition = thisTrack.transform.position;
            spawnPosition.z -= (numberOfRowsBehindPlayer) * Section.ZDistanceBetweenRows;
            return spawnPosition;
        }
        
        private void InitializeSpawnSections() => sectionsToLoad = new Queue<Section>();
        
        private void AddAllSectionsToSpawn()
        {
            for (int i = 0; i < sections.Length; i++)
            {
                Section newInstantiatedSection = SpawnTrackSection(sections[i]).GetComponentInChildren<Section>();
                newInstantiatedSection.InitSection(newInstantiatedSection.gameObject);
                sectionsToLoad.Enqueue(newInstantiatedSection);
            }
        }
        
        private void InitializeDespawnSections()
        {
            trackCompletelyDespawned = false;
            sectionsToDespawn = new Queue<Section>();
        }

        private void GetNextLoadSection()
        {
            currentSectionLoadingRows = sectionsToLoad.Dequeue().GetComponentInChildren<Section>();
            sectionsToDespawn.Enqueue(currentSectionLoadingRows);
        }

        private void GetNextDespawnSection()
        {
            currentSectionDespawningRows = sectionsToDespawn.Dequeue();
        }
        
        public void AttemptToSpawnNextRow()
        {
            if (trackCompletelySpawned) return;
            
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

            Debug.Log("Spawned the full track.");
            trackCompletelySpawned = true;
        }

        private bool AreThereAnyMoreSectionsToSpawn() => sectionsToLoad.Count > 0;
        
        private bool AreThereAnyMoreSectionsToDespawn() => sectionsToDespawn.Count > 0;

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