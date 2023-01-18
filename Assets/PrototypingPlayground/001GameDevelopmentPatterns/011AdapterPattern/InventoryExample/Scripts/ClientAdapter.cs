using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample.InventoryAsset;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample.InventoryAssetAdapter;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample
{
    public class ClientAdapter : MonoBehaviour
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
