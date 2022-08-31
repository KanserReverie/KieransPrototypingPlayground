using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._2.StateMachine.Obstacle
{
    public class EndGameObjectActions : MonoBehaviour
    {
        private void OnCollisionStay(Collision other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            
            Debug.Log("YOU WIN!!!");
                #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
    }
}
