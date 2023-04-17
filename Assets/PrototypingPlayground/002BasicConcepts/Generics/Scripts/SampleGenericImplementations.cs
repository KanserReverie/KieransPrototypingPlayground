using System;
using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.Generics.Scripts
{
    public class SampleGenericImplementations <T>
    {
        // This will count how many times we have run this
        public int outputCount;

        private void PrintType()
        {
            Debug.Log($"Type of this class = {typeof(T)}");
        }
        
        // Takes in any class type object and returns the object.
        public U OutputAnyType<U>(U _parameter)
        {
            PrintType();
            outputCount++;
            return _parameter;
        }
    }
}
