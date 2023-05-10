using System.Collections.Generic;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.ExternalInventoryAsset;
using UnityEngine;
// ReSharper disable All
namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.InventorySavingAdapter
{
    /// <summary>
    /// This would be the adapter to make our inventory asset save to local disk.
    /// It then needs to sync up the local and cloud inventories.
    ///
    /// We are inheriting ALL the Inventory methods and adding functionality to the ones we need.
    /// </summary>
    public class InventorySystemAdapter: InventorySystem, IInventorySystem 
    {
        private List<InventoryItem> cloudInventory;

        public void SyncInventories() 
        {
            List<InventoryItem> cloudInventory = GetInventory();

            Debug.Log("Synchronizing local drive and cloud inventories");
        }

        public void AddItem(InventoryItem _item, SaveLocation _location)
        {
            if (_location == SaveLocation.Cloud)
            {
                AddItem(_item);
            }

            if (_location == SaveLocation.Local)
            {
                Debug.Log("Adding item to local drive");
            }

            if (_location == SaveLocation.Both)
            {
                Debug.Log("Adding item to local drive and on the cloud");
            }
        }

        public void RemoveItem(InventoryItem _item, SaveLocation _location) 
        {
            Debug.Log("Remove item from local/cloud/both");
        }

        public List<InventoryItem> GetInventory(SaveLocation _location) 
        {
            Debug.Log("Get inventory from local/cloud/both");
            
            return new List<InventoryItem>();
        }
    }
}
