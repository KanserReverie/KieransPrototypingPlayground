using UnityEngine;
// ReSharper disable All
namespace PrototypingPlayground._004QuickPrototypes.MenuItems.Scripts
{
    public class NameBehaviour : MonoBehaviour
    {
        [ContextMenuItem("Randomize Name", "Randomize")]
        [ContextMenuItem("Reset Name", "ResetName")]
        public string Name;

        private void Randomize()
        {
            Name = "Some Random Name";
        }
        
        private void ResetName()
        {
            Name = string.Empty;
        }
    }
}
