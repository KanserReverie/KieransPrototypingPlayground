using UnityEngine;
namespace PrototypingPlayground._002BasicConcepts.ConstReadonlyStaticReadonly
{
    public class ConstManager : MonoBehaviour
    {
        private const string CONST_TEST = "this is a const";

        private void Start()
        {
            Debug.Log($"This is the {gameObject.name} - \n CONST_TEST = '{CONST_TEST}' => Can only change in script declaration & not in inspector");
        }
    }
}
