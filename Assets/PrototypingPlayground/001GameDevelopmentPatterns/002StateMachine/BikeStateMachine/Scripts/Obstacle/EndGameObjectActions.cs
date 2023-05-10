using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._002StateMachine.BikeStateMachine.Obstacle
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
