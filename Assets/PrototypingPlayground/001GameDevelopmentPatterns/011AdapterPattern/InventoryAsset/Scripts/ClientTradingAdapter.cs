using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.ExternalInventoryAsset;
using PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset.InventoryTradingAdapter;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._011AdapterPattern.InventoryAsset
{
    public class ClientTradingAdapter : MonoBehaviour
    {
        public InventoryItem itemToAdd;
        public InventoryItem itemToRemove;
        [Header("Trading")]
        public InventoryItem itemReceiving;
        public InventoryItem itemGiving;

        private IInventorySystem inventorySystemTradingAdapter;

        private void Start()
        {
            inventorySystemTradingAdapter = new InventorySystemTradeAdapter();
        }
        
        private void OnGUI()
        {
            GUILayout.Label("How to use: Add items to your inventory and you can print them.", GUI.skin.box);
            GUILayout.Label("(We are pretending) the original Inventory Asset only enabled Saving to Cloud.", GUI.skin.box);
            GUILayout.Label("Our Trading Adapter is what we are using to add trading functionality.", GUI.skin.box);
            GUILayout.Space(10);
            
            if (GUILayout.Button("Add item (with adapter) to trade inventory."))
            {
                inventorySystemTradingAdapter.AddItemToTradeInventory(itemToAdd);
            }
            if (GUILayout.Button("Remove item (with adapter) from trade inventory."))
            {
                inventorySystemTradingAdapter.RemoveItemFromTradeInventory(itemToRemove);
            }
            if (GUILayout.Button("Trade for item (with adapter) from trade inventory."))
            {
                inventorySystemTradingAdapter.TradeItem(itemReceiving, itemGiving);
            }
            if (GUILayout.Button("Print items (with adapter) in trade inventory."))
            {
                inventorySystemTradingAdapter.PrintTradeInventory();
            }
        }
    }
}
