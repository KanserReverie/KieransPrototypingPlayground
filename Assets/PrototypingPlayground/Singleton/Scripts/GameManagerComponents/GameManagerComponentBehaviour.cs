// Creator: 
// Creation Time: 2022/06/11 10:25
using System;
using UnityEngine;
namespace PrototypingPlayground.Singleton.GameManagerComponents
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