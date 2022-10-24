using UnityEngine;
using UnityEngine.SceneManagement;
namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.Obstacle
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
