using UnityEngine;

namespace PrototypingPlayground.UsefulScripts
{
    public class FollowGameObject : MonoBehaviour
    {
        [SerializeField] private Transform transformToFollow;
        [SerializeField] private bool followRotation = false;
        [SerializeField] private Vector3 offset;
        
        // Update is called once per frame
        void Update()
        {
            this.transform.position = transformToFollow.position + offset;
            if (followRotation)
                this.transform.rotation = transformToFollow.rotation;
        }
        void OnValidate()
        {
            if (transformToFollow == null)
                return;
            transform.position = transformToFollow.position + offset;
            if (followRotation)
            {
                transform.rotation = transformToFollow.rotation;
            }
        }
    }
}
