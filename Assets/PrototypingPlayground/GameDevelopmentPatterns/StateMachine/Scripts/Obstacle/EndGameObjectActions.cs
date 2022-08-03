using UnityEngine;
namespace PrototypingPlayground.StateMachine.Obstacle
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
