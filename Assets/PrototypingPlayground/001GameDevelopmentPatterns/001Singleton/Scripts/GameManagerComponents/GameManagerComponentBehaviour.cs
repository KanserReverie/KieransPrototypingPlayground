// Creator: 
// Creation Time: 2022/06/11 10:25
using System;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GameManagerComponents
{
	[Serializable]
	public class GameManagerComponentBehaviour : MonoBehaviour
	{
		private void OnEnable()
		{
			GameManager.Instance.AddGameManagerComponent(this);
		}

		private void OnDisable()
		{
			GameManager.Instance.RemoveGameManagerComponent(this);
		}
	}
}