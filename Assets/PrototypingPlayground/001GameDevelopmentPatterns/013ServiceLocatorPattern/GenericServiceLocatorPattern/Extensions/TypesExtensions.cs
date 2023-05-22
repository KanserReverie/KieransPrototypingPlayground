using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._013ServiceLocatorPattern.GenericServiceLocatorPattern.Extensions
{
    public static class TypesExtensions
    {
        public static bool IsMonoBehaviour(this Type t)
        {
            return typeof(MonoBehaviour).IsAssignableFrom(t);
        }
    }
}
