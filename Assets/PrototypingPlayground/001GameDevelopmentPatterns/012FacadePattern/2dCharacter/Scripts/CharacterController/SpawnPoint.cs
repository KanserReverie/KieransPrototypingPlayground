using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class SpawnPoint : MonoBehaviour
    {
        public Vector3 SpawnLocation => transform.position;
    }
}
