using System.Collections.Generic;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.ExternalInventoryAsset
{
    /// <summary>
    /// Imagine this is an asset for an inventory system.
    /// </summary>
    public class InventorySystem
    {
        public void AddItem(InventoryItem item)
        {
            Debug.Log("Adding item to the cloud");
        }

        public void RemoveItem(InventoryItem item)
        {
            Debug.Log("Removing item from the cloud.");
        }

        public List<InventoryItem> GetInventory()
        {
            Debug.Log("Returning an inventory list stored in the cloud");

            return new List<InventoryItem>();
        }
    }
}
