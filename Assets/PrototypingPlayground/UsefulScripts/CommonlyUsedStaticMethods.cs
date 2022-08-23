using UnityEngine;
using UnityEngine.SceneManagement;
namespace PrototypingPlayground.UsefulScripts
{
    public static class CommonlyUsedStaticMethods
    {
        /// <summary>
        /// In build - Quits the game
        /// In playmode - Ends the playmode 
        /// </summary>
        public static void QuitGame()
        {
            Debug.Log($"Quitting Game");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
        
        /// <summary>
        /// This will reset the current scene.
        /// </summary>
        public static void ResetCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
