// Creator: Kieran
// Creation Time: 2022/06/11 9:16
using System.Collections.Generic;
using PrototypingPlayground.Singleton.GameManagerComponents;
using UnityEngine;
using UnityEngine.Serialization;

namespace PrototypingPlayground.Singleton
{
	public class GameManager : Singleton<GameManager>
	{
		[SerializeField] private bool resetListOnValidate = false;
		// ReSharper disable once CollectionNeverQueried.Local
		[SerializeField] private List<GameManagerComponent> gameManagerComponents;

		public void AddGameManagerComponent(GameManagerComponent gameManagerComponent)
		{
			gameManagerComponents.Add(gameManagerComponent);
		}
		
		public void RemoveGameManagerComponent(GameManagerComponent gameManagerComponent)
		{
			gameManagerComponents.Remove(gameManagerComponent);
		}

		private void OnValidate()
		{
			if (!resetListOnValidate)
				return;
			gameManagerComponents.Clear();
			GameManagerComponent[] gameManagerComponentsInScene;
			gameManagerComponentsInScene = GameObject.FindObjectsOfType<GameManagerComponent>();
			foreach (var component in gameManagerComponentsInScene)
			{
				gameManagerComponents.Add(component);
			}
		}
	}
}