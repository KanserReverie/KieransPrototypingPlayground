using System;
using UnityEngine;
using UnityEngine.Assertions;
namespace PrototypingPlayground._001GameDevelopmentPatterns._010SpatialPartition.MotorBikeLevelEditor.Track
{
    /// <summary>
    /// A track is made from many sections.
    /// </summary>
    public class Track : MonoBehaviour
    {
        [SerializeField] private Section[] sections;

        private void Awake()
        {
            Assert.IsTrue(sections.Length > 0);
            foreach (Section segmentOfTrack in sections)
            {
                Assert.IsNotNull(segmentOfTrack);
                segmentOfTrack.AssertRowsAreNotNull();
            }
        }

        public void Start()
        {
            // todo: Spawn each section of track
        }
    }
}