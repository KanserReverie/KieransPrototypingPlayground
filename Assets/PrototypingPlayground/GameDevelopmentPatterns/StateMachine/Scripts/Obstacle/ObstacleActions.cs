using UnityEngine;
using UnityEngine.SceneManagement;
namespace PrototypingPlayground.GameDevelopmentPatterns.StateMachine.Obstacle
{
    public class ObstacleActions : MonoBehaviour
    {
        private void OnCollisionStay(Collision other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            
            Debug.Log("TRY AGAIN");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
