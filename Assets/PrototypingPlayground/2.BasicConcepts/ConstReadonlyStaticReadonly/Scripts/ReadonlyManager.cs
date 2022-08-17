using UnityEngine;
namespace PrototypingPlayground._2.BasicConcepts.ConstReadonlyStaticReadonly.Scripts
{
    public class ReadonlyManager : MonoBehaviour
    {
        [SerializeField] private readonly string _readonlyTest = "this is a readonly";

        private void Start()
        {
            Debug.Log($"This is the {gameObject.name} - \n _readonlyTest = '{_readonlyTest}' => Can change only change in script declaration & constructor");
        }

        public ReadonlyManager()
        {
            _readonlyTest = "changed in the constructor";
        }
    }
}
