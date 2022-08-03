using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Drones
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> Done { get; set; }

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
        [SerializeField]

        public void Start()
        {
            CurrentHealth = maxHealth + 10;
            Debug.Log(CurrentHealth);
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
            CurrentHealth -= maxHealth;
        }
        private void AttackPlayer()
        {
            throw new NotImplementedException();
        }
        
        
        private void ResetDrone()
        {
            throw new NotImplementedException();
        }

    }
}
