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

            Debug.Log("See more here ->https://docs.unity3d.com/ScriptReference/RuntimeInitializeLoadType.html");
            Debug.Log("---- Start() - END ----");

            Debug.Log("CODE IS COMMENTED OUT OTHERWISE IT WILL RUN ON EVERY SCENE");
            Debug.Log("REMOVE COMMENTS TO SEE IT IN ACTION");
        }
        // !!!!!!!!!!!!!!!!!!!!!!!!!!! DISCLAIMER !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //
        // !!!!!!!!!!!!!!!!!------->     Uncomment all the code below to see it in action.!!!!!!!!!!!!!!!!!!!!!
        //
        //
        // I have it commented so this doesn't run EVERY SCENE
        // USES :
        // ||Service locator pattern|| to make sure references are made OR 
        // ||Instantiating managers|| loaded from resources :D
        //
        //
        // ALSO TO NOTE THERE ARE METHODS FOR RUNNING CODE IN EDITOR BEFORE OTHER STUFF RUNS :)
        // See the package particle effects and the read me always opens first.
        //
        //
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// 
        // [UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        // static void OnBeforeSceneLoadRuntimeMethod()
        // {
        //     Debug.Log("[UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]\n" +
        //               "Before first Scene loaded");
        // }
// 
        // [UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        // static void OnAfterSceneLoadRuntimeMethod()
        // {
        //     Debug.Log("[UnityEngine.RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]\n" +
        //               "After first Scene loaded");
        // }
// 
        // [UnityEngine.RuntimeInitializeOnLoadMethod]
        // static void OnRuntimeMethodLoad()
        // {
        //     Debug.Log("[UnityEngine.RuntimeInitializeOnLoadMethod]\n" +
        //               "RuntimeMethodLoad: After first Scene loaded");
        //     Debug.Log("RuntimeMethodLoad: After first Scene loaded");
        // }
    }
}
