using UnityEngine;
namespace PrototypingPlayground.CustomInspector.SerializableProperties
{
    [System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class ReadOnlyFieldAttribute : PropertyAttribute { }
}
