using UnityEngine;

namespace PrototypingPlayground.SerializableProperties
{
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class ReadOnlyFieldAttribute : PropertyAttribute { }
}
