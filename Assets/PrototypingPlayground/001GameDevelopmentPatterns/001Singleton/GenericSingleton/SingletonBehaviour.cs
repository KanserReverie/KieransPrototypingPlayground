// Creator: 
// Creation Time: 2022/06/10 9:55

using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GenericSingleton
{
	public class SingletonBehaviour<T> : MonoBehaviour where T : Component
	{
		private static T instance;

		// 1. Check _instance is null.
		// 2. Check if one is already in scene.
		// 3. If none is in scene create a new GameObject and attach .this component to it.
		// 4. Make _instance = this new component.
		public static T Instance
		{
			get
			{
				if(instance == null)
				{
					instance = FindObjectOfType<T>();

					if(instance == null)
					{
						GameObject tempGameObject = new GameObject();
						tempGameObject.name = typeof(T).Name;
						instance = tempGameObject.AddComponent<T>();
					}
				}
				return instance;
			}
		}
 
		// ---Awake is called when the script is being loaded. (Not just before start)---
		// 1. Check if WE are the one in scene.
		// 2. If we are then dont destroy this.
		// 3. If we are not then destroy this. GameObject.
		public virtual void Awake()
		{
			if(instance == null || instance == this)
			{
				instance = this as T;
				DontDestroyOnLoad(gameObject);
			} 
			else
			{
				Destroy(gameObject);
			}
		}
	}
}