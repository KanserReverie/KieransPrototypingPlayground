using UnityEngine;
using UnityEngine.Events;
// ReSharper disable All
namespace PrototypingPlayground._002BasicConcepts.UnityEvents
{
    [RequireComponent(typeof(Rigidbody))]
    public class MainBox : MonoBehaviour
    {
        public UnityEvent boxHitGround;

        private Rigidbody boxRigidbody;

        [SerializeField] private float upForce = 4f;
        
        [SerializeField] private float gravityMultiplier = 2f;

        [SerializeField, Range(0.02f, 0.001f)] private float timeScale = 0.01f;
        private float lastTimeScale;

        private void Start()
        {
            lastTimeScale = timeScale;
            boxRigidbody = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            if(lastTimeScale != timeScale)
                Time.fixedDeltaTime = timeScale;
            lastTimeScale = timeScale;
        }

        public void FixedUpdate() => boxRigidbody.AddForce(Physics.gravity * gravityMultiplier);

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag($"InvisibleWall"))
                return;
            boxRigidbody.AddForce(0.1f * upForce,upForce,0.1f * upForce);
            boxHitGround.Invoke();
        }
    }
}