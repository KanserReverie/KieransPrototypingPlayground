using UnityEngine;

namespace PrototypingPlayground.UsefulScripts
{
    public class FollowGameObject : MonoBehaviour
    {
        [SerializeField] private Transform transformToFollow;
        [SerializeField] private bool followRotation = false;
        
        // Update is called once per frame
        void Update()
        {
            this.transform.position = transformToFollow.position;
            if (followRotation)
                this.transform.rotation = transformToFollow.rotation;
        }
    }
}
