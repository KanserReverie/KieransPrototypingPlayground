using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class RespawnSystem : MonoBehaviour
    {
        public Vector3 GetSpawnLocation()
        {
            SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
            
            if (spawnPoint != null)
            {
                return spawnPoint.SpawnLocation;
            }
            else
            {
                return Vector3.zero;
            }
        }
    }
}
