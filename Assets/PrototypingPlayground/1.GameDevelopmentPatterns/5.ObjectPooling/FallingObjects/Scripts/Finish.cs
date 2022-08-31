using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._5.ObjectPooling.FallingObjects
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 60f;
        // Update is called once per frame
        void Update()
        {
            transform.Rotate(rotationSpeed * 0.6f * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * 0.01f * Time.deltaTime);
        }
    }
}
