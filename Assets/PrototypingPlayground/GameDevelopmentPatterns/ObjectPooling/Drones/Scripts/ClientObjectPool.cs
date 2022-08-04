using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
namespace PrototypingPlayground.GameDevelopmentPatterns.ObjectPooling.Drones
{
    public class ClientObjectPool : MonoBehaviour
    {
        private DroneObjectPool pool;
        private int numberOfDronesToSpawn;

        private void Start()
        {
            pool = gameObject.AddComponent<DroneObjectPool>();
        }

        private void OnGUI()
        {
            numberOfDronesToSpawn = EditorGUILayout.IntSlider(numberOfDronesToSpawn, 1, 5);
            if(GUILayout.Button("Spawn Drones"))
                Spawn();
        }
        
        public void Spawn()
        {
            for (int i = 0; i < numberOfDronesToSpawn; i++)
            {
                Drone drone = pool.Pool.Get();
                drone.transform.position = Random.insideUnitSphere * 10;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            
            Gizmos.DrawWireSphere(transform.position, 10);
        }
    }
}
