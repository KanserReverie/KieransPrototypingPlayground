using UnityEngine;
using UnityEngine.SceneManagement;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._2.StateMachine.Obstacle
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
