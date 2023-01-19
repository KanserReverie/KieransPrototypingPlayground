using System.Collections.Generic;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample.InventoryAsset;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryExample.InventoryTradingAdapter
{
    /// <summary>
    /// This is where we will add our extra functions as well as the current ones.
    /// </summary>
    public interface IInventorySystem
    {
        void AddItemToTradeInventory(InventoryItem _item);

        void RemoveItemFromTradeInventory(InventoryItem _item);

        bool IsItemInInventory(InventoryItem _item);

        InventoryItem TradeItem(InventoryItem _itemReceiving, InventoryItem _itemGiving);
        
        List<InventoryItem> GetInventory();
        void PrintTradeInventory();
    }
}
