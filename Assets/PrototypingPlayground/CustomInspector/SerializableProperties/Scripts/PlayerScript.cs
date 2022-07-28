using UnityEngine;
namespace PrototypingPlayground.CustomInspector.SerializableProperties
{
    public class PlayerScript : MonoBehaviour
    {
        public int Name { get; set;}
        [field: SerializeField] public int Health { get; private set;}
        [field: SerializeField, ReadOnlyField] public int Mana { get; set;}
    }
}
