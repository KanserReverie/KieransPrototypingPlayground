using System.Collections.Generic;
using System.Linq;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.ExternalInventoryAsset;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.InventoryTradingAdapter
{
    /// <summary>
    /// In this example we are going to hold a trade inventory and enable trading.
    /// </summary>
    public class InventorySystemTradeAdapter : InventorySystem, IInventorySystem
    {
        private List<InventoryItem> inventory = new List<InventoryItem>();
        
        public void AddItemToTradeInventory(InventoryItem item)
        {
            AddItem(item);
            
            inventory.Add(item);
            Debug.Log("Adding item to your trade inventory.");
        }
        
        public void RemoveItemFromTradeInventory(InventoryItem item)
        {
            RemoveItem(item);
            
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i] == item)
                {
                    inventory.RemoveAt(i);
                    Debug.Log("Removing item from your trade inventory.");
                    return;
                }
            }
        }
        
        public void PrintTradeInventory()
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Debug.Log($"Inventory Item {i} = {inventory[i]}");
            }
        }
        
        /// <summary>
        /// This is the new method we are going to create to add to the asset.
        /// </summary>
        public InventoryItem TradeItem(InventoryItem itemReceiving, InventoryItem itemGiving)
        {
            if (IsItemInInventory(itemGiving))
            {
                RemoveItemFromTradeInventory(itemGiving);
                AddItemToTradeInventory(itemReceiving);
                Debug.Log($"Trade Complete: Received {itemReceiving} for your {itemReceiving}");
                return itemGiving;
            }
            else
            {
                Debug.Log($"Unable to Trade: You don't have a {itemGiving} to trade.");
                return itemReceiving;
            }
        }
        
        public bool IsItemInInventory(InventoryItem item)
        {
            return inventory.Any(inventoryItem => inventoryItem == item);
        }
    }
}
