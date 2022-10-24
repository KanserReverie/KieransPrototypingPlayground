using UnityEngine;
namespace PrototypingPlayground._002BasicConcepts.UnityEvents
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
