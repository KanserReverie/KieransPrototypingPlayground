// Creator: Kieran
// Creation Time: 2022/06/11 9:16

using System.Collections.Generic;
using UnityEngine;
using PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GameManagerSingleton.GameManagerComponents;
using PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GenericSingleton;

namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GameManagerSingleton
{
	public class GameManager : SingletonBehaviour<GameManager>
	{
		[SerializeField] private bool resetListOnValidate = false;
		// ReSharper disable once CollectionNeverQueried.Local
		[SerializeField] private List<GameManagerComponentBehaviour> gameManagerComponents;

		public void AddGameManagerComponent(GameManagerComponentBehaviour _gameManagerComponentBehaviour)
		{
			gameManagerComponents.Add(_gameManagerComponentBehaviour);
		}
		
		public void RemoveGameManagerComponent(GameManagerComponentBehaviour _gameManagerComponentBehaviour)
		{
			gameManagerComponents.Remove(_gameManagerComponentBehaviour);
		}

		private void OnValidate()
		{
			if (!resetListOnValidate)
				return;
			gameManagerComponents.Clear();
			GameManagerComponentBehaviour [] gameManagerComponentsInScene = FindObjectsOfType<GameManagerComponentBehaviour>();
			foreach (GameManagerComponentBehaviour component in gameManagerComponentsInScene)
			{
				gameManagerComponents.Add(component);
			}
		}
	}
}