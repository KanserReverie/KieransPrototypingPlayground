using UnityEngine;

namespace PrototypingPlayground._004QuickPrototypes.DestroyAndReturnInAMethod.Scripts
{
    public class DestroyAndReturn : MonoBehaviour
    {
        public DestroyAndReturn RunDestroyAndReturn()
        {
            Debug.Log("");
            Debug.Log("DestroyAndReturn.RunDestroyAndReturn()\n [..|YOU ARE HERE|..Destroy(this.gameObject)....return this;....]");
            Destroy(this.gameObject);
            Debug.Log("DestroyAndReturn.RunDestroyAndReturn()\n [....Destroy(this.gameObject)..|YOU ARE HERE|..return this;....]");
            Debug.Log("");
            return this;
        }

        private void OnDestroy()
        {
            Debug.Log("");
            Debug.Log("DestroyAndReturn -> GameObjectDestroyed");
            Debug.Log("");
        }
    }
}
