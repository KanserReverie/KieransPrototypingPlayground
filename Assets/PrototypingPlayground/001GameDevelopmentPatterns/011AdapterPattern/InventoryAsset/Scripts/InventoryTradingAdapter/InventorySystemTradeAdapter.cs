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
        
        public void AddItemToTradeInventory(InventoryItem _item)
        {
            AddItem(_item);
            
            inventory.Add(_item);
            Debug.Log("Adding item to your trade inventory.");
        }
        
        public void RemoveItemFromTradeInventory(InventoryItem _item)
        {
            RemoveItem(_item);
            
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i] == _item)
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
        public InventoryItem TradeItem(InventoryItem _itemReceiving, InventoryItem _itemGiving)
        {
            if (IsItemInInventory(_itemGiving))
            {
                RemoveItemFromTradeInventory(_itemGiving);
                AddItemToTradeInventory(_itemReceiving);
                Debug.Log($"Trade Complete: Received {_itemReceiving} for your {_itemReceiving}");
                return _itemGiving;
            }
            else
            {
                Debug.Log($"Unable to Trade: You don't have a {_itemGiving} to trade.");
                return _itemReceiving;
            }
        }
        
        public bool IsItemInInventory(InventoryItem _item)
        {
            return inventory.Any(_inventoryItem => _inventoryItem == _item);
        }
    }
}
