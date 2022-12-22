using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.MotorBikeLevelEditor.Managers
{
    public class LevelManager : MonoBehaviour
    {
        // Track -> TrackManager
        // Speed -> TrackManager
        // Skybox -> SkyboxManager
        // Music -> MusicManager
        
        // Once all is loaded
            // Runs MusicManager - Load(Music) -> Starts Playing Music on loop
            // Runs TrackManager - Load(Track, Speed) -> Load Initial Track, plays it at Speed
            // Runs SkyboxManager - Load(Skybox) -> Loads Skybox
    }
}
