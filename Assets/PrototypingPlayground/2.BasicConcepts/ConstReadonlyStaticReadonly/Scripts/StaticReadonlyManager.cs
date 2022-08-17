using UnityEngine;
namespace PrototypingPlayground._2.BasicConcepts.ConstReadonlyStaticReadonly.Scripts
{
    public class StaticReadonlyManager : MonoBehaviour
    {
        [SerializeField] private static readonly string StaticReadonlyTest = "this is a static readonly";

        private void Start()
        {
            Debug.Log($"This is the {gameObject.name} - \n StaticReadonlyTest = '{StaticReadonlyTest}' => Can change in script declaration & a 'static' constructor");
        }

        static StaticReadonlyManager()
        {
            StaticReadonlyTest = "changed in the 'static' constructor";
        }
    }
}
