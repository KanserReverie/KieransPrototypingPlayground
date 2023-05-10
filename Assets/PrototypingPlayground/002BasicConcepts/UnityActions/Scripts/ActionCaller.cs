using UnityEngine;
using UnityEngine.Events;
// ReSharper disable All
namespace PrototypingPlayground._002BasicConcepts.UnityActions
{
    public class ActionCaller : MonoBehaviour
    {
        private UnityAction firstUnityAction;
        [SerializeField] private UnityEvent onFirstUnityEvent;
        
        private void Start()
        {
            Debug.Log("UnityActions (same as actions) send out a message when called..." +
                      "\n...other objects can listen for this message and react to it accordingly :)");
                      
            Debug.Log("UnityActions vs UnityEvents");
            Debug.Log("Unity Events - They are serializable event based delegates" +
                      "\nPROs: They are SERIALIZABLE delegates. CONs: They use an EVENT system and thus expensive.");
            Debug.Log("UnityActions - They are a simple delegates that can take in multiple parameters" +
                      "\nPROs: Not as expensive and can take in different parameters. CONs: Not Serializable.");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Clear Listeners from UnityAction and UnityEvent"))
            {
                ClearUnityAction();
            }
            if (GUILayout.Button("Add Change Colour to UnityAction"))
            {
                AddChangeColourToAction();
            }
            if (GUILayout.Button("Add Change Colour to UnityEvent"))
            {
                AddChangeColourToEvent();
            }
            if (GUILayout.Button("Call UnityAction"))
            {
                firstUnityAction?.Invoke();
            }
            if (GUILayout.Button("Invoke UnityEvent"))
            {
                onFirstUnityEvent?.Invoke();
            }
        }

        private void AddUnityActionToUnityEvent()
        {
            Debug.Log("We can add UnityAction to our UnityEvent");
            onFirstUnityEvent.AddListener(firstUnityAction);
        }
        
        private void AddChangeColourToAction()
        {
            Debug.Log("Added a 'void ChangeCubeColor()'/[actionReceiver.ChangeCubeColor] to our UnityAction");
            ActionReceiver actionReceiver = GameObject.FindObjectOfType<ActionReceiver>();
            firstUnityAction += actionReceiver.ChangeCubeColor;
        }

        private void AddChangeColourToEvent()
        {
            Debug.Log("Added a 'void ChangeCubeColor()'/[actionReceiver.ChangeCubeColor] to our UnityEvent");
            ActionReceiver actionReceiver = GameObject.FindObjectOfType<ActionReceiver>();
            onFirstUnityEvent.AddListener(actionReceiver.ChangeCubeColor);
        }
        
        private void ClearUnityAction()
        {
            firstUnityAction = null;
            onFirstUnityEvent = null;
            Debug.Log($"Unity _firstUnityAction = {firstUnityAction} (null) " +
                      $"\n Unity firstUnityEvent = {onFirstUnityEvent} (null)");
        }
    }
}
