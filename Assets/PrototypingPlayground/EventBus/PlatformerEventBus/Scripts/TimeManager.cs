using System;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField]
        private float spawnTimer = 3;
        private float _currrentSpawnTimer;

        private void Start()
        {
            _currrentSpawnTimer = spawnTimer;
        }
    }
}
