using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._5.ObjectPooling.Drones
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> Pool { get; set; }

        private float currentHealth;
        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value > maxHealth) 
                    value = maxHealth;
                if (value < 0) 
                    value = 0;
                currentHealth = value;
            }
        }

        [SerializeField] private float maxHealth = 100.0f;
        [SerializeField] private float timeToSelfDestruct = 3.0f;

        public void Start()
        {
            CurrentHealth = maxHealth;
        }

        private void OnEnable()
        {
            StartCoroutine(SelfDestruct());
            AttackPlayer();
        }

        private void OnDisable()
        {
            ResetDrone();
        }

        private IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }
        public void TakeDamage(float _amount)
        {
            CurrentHealth -= _amount;

            if (CurrentHealth <= 0)
            {
                ReturnToPool();
            }
        }
        private void ReturnToPool()
        {
            Pool.Release(this);
        }
        private void AttackPlayer()
        {
            Debug.Log("Attacking Player");
        }
        
        private void ResetDrone()
        {
            CurrentHealth = maxHealth;
        }

        private void OnDrawGizmosSelected()
        {
            Handles.Label(transform.position, $"{gameObject.name}");
        }
    }
}
