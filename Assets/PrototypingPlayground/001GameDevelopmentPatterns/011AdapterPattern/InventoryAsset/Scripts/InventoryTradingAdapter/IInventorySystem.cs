using System.Collections.Generic;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.ExternalInventoryAsset;
namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.InventoryTradingAdapter
{
    /// <summary>
    /// This is where we will add our extra functions as well as the current ones.
    /// </summary>
    public interface IInventorySystem
    {
        void AddItemToTradeInventory(InventoryItem item);

        void RemoveItemFromTradeInventory(InventoryItem item);

        bool IsItemInInventory(InventoryItem item);

        InventoryItem TradeItem(InventoryItem itemReceiving, InventoryItem itemGiving);
        
        List<InventoryItem> GetInventory();
        void PrintTradeInventory();
    }
}
