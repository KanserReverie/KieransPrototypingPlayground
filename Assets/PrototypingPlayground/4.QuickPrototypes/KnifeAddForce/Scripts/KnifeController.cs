using System;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;

namespace PrototypingPlayground._4.QuickPrototypes.KnifeAddForce
{
    public class KnifeController : MonoBehaviour
    {
        private Rigidbody knifeRigidbody;
        private bool displayGUI;

        private void Start()
        {
            displayGUI = false;
            knifeRigidbody = GetComponent<Rigidbody>();
            knifeRigidbody.isKinematic = true;
            knifeRigidbody.useGravity = false;
        }

        [SerializeField] private Rect startingPoint;
        private void OnGUI()
        {
            if (displayGUI)
            {
                GUILayout.BeginArea(startingPoint);
                if (GUILayout.Button("Turn off GUI || [Del]"))
                {
                    displayGUI = false;
                }
                if (GUILayout.Button("Quit Game || [Esc]"))
                {
                    CommonlyUsedStaticMethods.QuitGame();
                }
                if (GUILayout.Button("Reset Game || [`]"))
                {
                    CommonlyUsedStaticMethods.ResetCurrentScene();
                }
                if (GUILayout.Button("Push cube"))
                {
                    Debug.Log("Push");
                }
                GUILayout.EndArea();
            }
        }
    }
}
