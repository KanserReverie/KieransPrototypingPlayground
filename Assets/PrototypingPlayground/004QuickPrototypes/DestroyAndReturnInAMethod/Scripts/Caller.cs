using PrototypingPlayground.UsefulScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
// ReSharper disable All

namespace PrototypingPlayground._004QuickPrototypes.DestroyAndReturnInAMethod.Scripts
{
    public class Caller : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;

        private bool haveWeRunDestroyAndReturn;
        private DestroyAndReturn destroyAndReturnComponent;
        private DestroyAndReturn returnedComponent;

        private void Awake()
        {
            Assert.IsNotNull(textMeshPro);
        }

        public void RunDestroyAndReturn()
        {
            Debug.Log("");
            Debug.Log("Caller.RunDestroyAndReturn()\n [..|YOU ARE HERE|..if(){..Find<>..DaR.RunDestroyAndReturn()..run=true..}....PrintReturned....]");
            if (!haveWeRunDestroyAndReturn)
            {
                Debug.Log("Caller.RunDestroyAndReturn()\n [....if(){.|YOU ARE HERE|.Find<>..DaR.RunDestroyAndReturn()..run=true..}....PrintReturned....]");
                destroyAndReturnComponent = FindObjectOfType<DestroyAndReturn>();
                Debug.Log("Caller.RunDestroyAndReturn()\n [....if(){..Find<>..|YOU ARE HERE|..DaR.RunDestroyAndReturn()....run=true..}....PrintReturned....]");
                returnedComponent = destroyAndReturnComponent.RunDestroyAndReturn();
                Debug.Log("Caller.RunDestroyAndReturn()\n [....if(){..Find<>..DaR.RunDestroyAndReturn().|YOU ARE HERE|.run=true..}....PrintReturned....]");
                haveWeRunDestroyAndReturn = true;
            }

            Debug.Log("Caller.RunDestroyAndReturn()\n [....if(){..Find<>..DaR.RunDestroyAndReturn()..run=true..}..|YOU ARE HERE|..PrintReturned....]");
            PrintReturnedComponentName();
            Debug.Log("Caller.RunDestroyAndReturn()\n [....if(){..Find<>..DaR.RunDestroyAndReturn()..run=true..}....PrintReturned..|YOU ARE HERE|..]");
            Debug.Log("");
        }

        private void PrintReturnedComponentName()
        {
            Debug.Log("");
            Debug.Log("Caller.PrintReturnedComponentName()\n [..|YOU ARE HERE|..if(cR!=null){..print..}....if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){..print..}..}....]");
            if (returnedComponent != null)
            {
                Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){.|YOU ARE HERE|.print..}....if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){..print..}..}....]");
                textMeshPro.text = ($"returnedComponent.name = {returnedComponent.name}");
                Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print.|YOU ARE HERE|.}....if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){..print..}..}....]");
            }

            Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}..|YOU ARE HERE|..if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){..print..}..}....]");
            if (returnedComponent == null)
            {
                Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){.|YOU ARE HERE|.print..}....if(cR!=null){..if(cR.name==null){..print..}..}....]");
                textMeshPro.text = ($"returnedComponent = null");
                Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){..print.|YOU ARE HERE|.}....if(cR!=null){..if(cR.name==null){..print..}..}....]");
            }

            Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){..print..}..|YOU ARE HERE|..if(cR!=null){..if(cR.name==null){..print..}..}....]");
            if (returnedComponent != null)
            {
                Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){..print..}....if(cR!=null){.|YOU ARE HERE|.if(cR.name==null){..print..}..}....]");
                if (returnedComponent.name == null)
                {
                    Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){.|YOU ARE HERE|.print..}..}....]");
                    textMeshPro.text = ($"returnedComponent.name = null");
                    Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){..print.|YOU ARE HERE|.}..}....]");
                }

                Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){..print..}.|YOU ARE HERE|.}....]");
            }

            Debug.Log("Caller.PrintReturnedComponentName()\n [....if(cR!=null){..print..}....if(rT==null){..print..}....if(cR!=null){..if(cR.name==null){..print..}..}..|YOU ARE HERE|..]");
            Debug.Log("");
        }

        private void Start()
        {
            Debug.Log("");
            ConsoleToGUI.InstantiateConsoleToGUIInScene(false);
            haveWeRunDestroyAndReturn = false;
            textMeshPro.text = "No Game Object Destroyed Yet";
            Debug.Log("This is to see if we will get a returned value before Destroy gameObject is called");
            Debug.Log("");
            Debug.Log("THE GAME OBJECT DOES NOT GET DESTROYED IMMEDIATELY AND YOU CAN USE THAT RETURNED VALUE FOR THAT LAST CHAIN OF METHODS!!");
            Debug.Log("");
        }
    }
}
