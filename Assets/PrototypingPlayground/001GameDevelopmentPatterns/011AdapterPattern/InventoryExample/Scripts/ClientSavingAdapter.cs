using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample.InventoryAsset;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample.InventorySavingAdapter;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample
{
    public class ClientSavingAdapter : MonoBehaviour
    {
        public InventoryItem item;
        
        private InventorySystem inventorySystem;
        private IInventorySystem inventorySystemAdapter;


        private void Start()
        {
            inventorySystem = new InventorySystem();
            inventorySystemAdapter = new InventorySystemAdapter();
        }

        private void OnGUI()
        {
            GUILayout.Label("How to use: Add items to your inventory.", GUI.skin.box);
            GUILayout.Label("(We are pretending) the original Inventory Asset only enabled Saving to Cloud.", GUI.skin.box);
            GUILayout.Label("Our Saving Adapter adds Saving Locally and to Cloud functionality.", GUI.skin.box);
            GUILayout.Space(10);

            if (GUILayout.Button("Add item (no adapter)"))
            {
                inventorySystem.AddItem(item);
            }

            if (GUILayout.Button("Add item (with adapter)"))
            {
                inventorySystemAdapter.AddItem(item, SaveLocation.Both);
            }
        }
    }
}
