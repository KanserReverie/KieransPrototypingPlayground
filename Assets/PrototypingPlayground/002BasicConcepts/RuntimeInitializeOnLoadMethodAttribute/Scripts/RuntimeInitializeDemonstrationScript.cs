using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.RuntimeInitializeOnLoadMethodAttribute
{
    public class RuntimeInitializeDemonstrationScript : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("---- Start() - BEGIN ----");
            Debug.Log("[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.\"xx\")] runs EVERY time the game is RUN or BUILT either:");
            
            Debug.Log("Before Scene AWAKE functions called - \"xx\"=BeforeSceneLoad");
            Debug.Log("After Scene AWAKE functions called - \"xx\"=AfterSceneLoad");
            Debug.Log("Callback when all assemblies loaded assets initialized - \"xx\"=AfterAssembliesLoaded");
            Debug.Log("Immediately before the splash screen is shown - \"xx\"=BeforeSplashScreen");
            Debug.Log("Callback used for registration of subsystems - \"xx\"=SubsystemRegistration");
            Debug.Log("------------------");
            
            Debug.Log("See more here\nhttps://docs.unity3d.com/ScriptReference/RuntimeInitializeLoadType.html");
            Debug.Log("---- Start() - END ----");
        }
        
        [UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            Debug.Log("[UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]\n" +
                      "Before first Scene loaded");
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnAfterSceneLoadRuntimeMethod()
        {
            Debug.Log("[UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]\n" +
                      "After first Scene loaded");
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod]
        static void OnRuntimeMethodLoad()
        {
            Debug.Log("[UnityEngine.RuntimeInitializeOnLoadMethod]\n" +
                      "RuntimeMethodLoad: After first Scene loaded");
            Debug.Log("RuntimeMethodLoad: After first Scene loaded");
        }
    }
}
