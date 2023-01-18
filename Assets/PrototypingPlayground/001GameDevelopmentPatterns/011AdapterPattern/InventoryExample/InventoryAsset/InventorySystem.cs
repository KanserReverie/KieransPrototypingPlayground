using System.Collections.Generic;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample.InventoryAsset
{
    /// <summary>
    /// Imagine this is an asset for an inventory system.
    /// </summary>
    public class InventorySystem
    {
        public void AddItem(InventoryItem _item)
        {
            Debug.Log("Adding item to the cloud");
        }

        public void RemoveItem(InventoryItem _item)
        {
            Debug.Log("Removing item from the cloud");
        }

        public List<InventoryItem> GetInventory()
        {
            Debug.Log("Returning an inventory list stored in the cloud");

            return new List<InventoryItem>();
        }
    }
}
