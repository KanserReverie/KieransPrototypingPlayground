using System.Collections.Generic;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.ExternalInventoryAsset;
namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.InventorySavingAdapter
{
    /// <summary>
    /// A client who uses this interface won't realise it's actually interacting with an adapted system.
    ///
    /// It just knows that it's able to add and remove an item and doesn't realise it's interacting with another adapted asset. 
    /// </summary>
    public interface IInventorySystem
    {
        void SyncInventories();

        void AddItem(InventoryItem item, SaveLocation location);

        void RemoveItem(InventoryItem item, SaveLocation location);

        List<InventoryItem> GetInventory(SaveLocation location);
    }
}
