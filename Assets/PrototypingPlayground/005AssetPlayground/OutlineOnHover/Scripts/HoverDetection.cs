using System;
using UnityEngine;

namespace PrototypingPlayground._005AssetPlayground.OutlineOnHover
{
    public class HoverDetection : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorTexture;
        [SerializeField] private GameObject[] targetObjects; // Array of target GameObjects to detect hover
        [SerializeField] private Outline outlineScript; // Outline script component to enable

        private void Start()
        {
            //foreach (var VARIABLE in COLLECTION)
            //{
            //    throw new NotImplementedException();
            //}
        }

        private void Update()
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hovered object is one of the target objects
                foreach (GameObject target in targetObjects)
                {
                    if (hit.collider.gameObject == target)
                    {
                        // Enable outline script on the target object
                        outlineScript.enabled = true;

                        // Change the cursor to cursorTexture
                        if (cursorTexture is not null)
                            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2),
                                CursorMode.Auto);
                        return;
                    }
                }
            }

            // Disable outline script if no target object is hovered
            outlineScript.enabled = false;

            // Reset the cursor to default
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
