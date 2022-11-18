using UnityEngine;
using System.Collections.Generic;
using PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.FighterDrones.DroneStrategies;

namespace PrototypingPlayground._001GameDevelopmentPatterns._008StrategyPattern.FighterDrones
{
    public class ClientStrategy : MonoBehaviour {

        private GameObject drone;

        private readonly List<IDroneStrategy> components = new List<IDroneStrategy>();

        private void SpawnDrone() 
        {
            drone = GameObject.CreatePrimitive(PrimitiveType.Cube);
            drone.AddComponent<Drone>();
            Vector3 spawanLocation = Random.insideUnitSphere * 10;
            spawanLocation.y = 2;
            drone.transform.position = spawanLocation;
            ApplyRandomStrategies();
        }

        private void ApplyRandomStrategies() 
        {
            components.Add(drone.AddComponent<WeavingManeuver>());
            components.Add(drone.AddComponent<BoppingManeuver>());
            components.Add(drone.AddComponent<FallbackManeuver>());
            components.Add(drone.AddComponent<DiagonalManeuver>());

            int index = Random.Range(0, components.Count);

            drone.GetComponent<Drone>().ApplyStrategy(components[index]);
        }

        void OnGUI() 
        {
            if (GUILayout.Button("Spawn Drone")) 
            { 
                SpawnDrone();
            }
        }
    }
}
