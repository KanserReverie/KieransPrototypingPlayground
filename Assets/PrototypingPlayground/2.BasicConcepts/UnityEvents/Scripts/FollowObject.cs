using UnityEngine;
namespace PrototypingPlayground._2.BasicConcepts.UnityEvents.Scripts
{
    public class FollowObject : MonoBehaviour
    {
        [SerializeField] private Transform transformToFollow;
        private void LateUpdate()
        {
            transform.position = transformToFollow.position;
        }
    }
}
