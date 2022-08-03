using UnityEngine;
using UnityEngine.Events;
namespace PrototypingPlayground.BasicConcepts.UnityEvents
{
    [RequireComponent(typeof(Rigidbody))]
    public class MainBox : MonoBehaviour
    {
        public UnityEvent boxHitGround;

        private Rigidbody _boxRigidbody;

        [SerializeField] private float upForce = 4f;
        
        [SerializeField] private float gravityMultiplier = 2f;

        [SerializeField, Range(0.02f, 0.001f)] private float timeScale = 0.01f;
        private float _lastTimeScale;

        private void Start()
        {
            _lastTimeScale = timeScale;
            _boxRigidbody = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            if(_lastTimeScale != timeScale)
                Time.fixedDeltaTime = timeScale;
            _lastTimeScale = timeScale;
        }

        public void FixedUpdate() => _boxRigidbody.AddForce(Physics.gravity * gravityMultiplier);

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag($"InvisibleWall"))
                return;
            _boxRigidbody.AddForce(0.1f * upForce,upForce,0.1f * upForce);
            boxHitGround.Invoke();
        }
    }
}