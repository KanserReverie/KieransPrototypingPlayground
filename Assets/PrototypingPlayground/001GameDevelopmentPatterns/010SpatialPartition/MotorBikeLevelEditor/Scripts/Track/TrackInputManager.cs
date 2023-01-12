using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.MotorBikeLevelEditor.Track
{
    public class TrackInputManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AttemptToDespawnLastRow();
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AttemptToSpawnNextRow();
            }
        }
        
        private static void AttemptToDespawnLastRow()
        {
            Track track = FindObjectOfType<Track>();
            if (track == null)
            {
                Debug.Log("Sorry, could not find a track in scene.");
                return;
            }
            else
            {
                Debug.Log("Attempt To Despawn Last Row");
            }
            if (!track.TrackCompletelyDespawned)
            {
                track.AttemptToDespawnLastRow();
            }
            else
            {
                Debug.Log("No more track to despawn.");
            }
        }
        
        private static void AttemptToSpawnNextRow()
        {
            Track track = FindObjectOfType<Track>();
            if (track == null)
            {
                Debug.Log("Sorry, could not find a track in scene.");
                return;
            }
            else
            {
                Debug.Log("Attempt To Spawn Next Row");
            }
            if (!track.TrackCompletelySpawned)
            { 
                track.AttemptToSpawnNextRow();
            }
            else
            {
                Debug.Log("No more track to spawn.");
            }
        }
    }
}
