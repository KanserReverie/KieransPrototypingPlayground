// Creator: Kieran
// Creation Time: 2022/06/11 9:16
using System.Collections.Generic;
using PrototypingPlayground.GameDevelopmentPatterns.Singleton.GameManagerComponents;
using UnityEngine;
namespace PrototypingPlayground.GameDevelopmentPatterns.Singleton
{
	public class GameManager : SingletonBehaviour<GameManager>
	{
		[SerializeField] private bool resetListOnValidate = false;
		// ReSharper disable once CollectionNeverQueried.Local
		[SerializeField] private List<GameManagerComponentBehaviour> gameManagerComponents;

		public void AddGameManagerComponent(GameManagerComponentBehaviour gameManagerComponentBehaviour)
		{
			gameManagerComponents.Add(gameManagerComponentBehaviour);
		}
		
		public void RemoveGameManagerComponent(GameManagerComponentBehaviour gameManagerComponentBehaviour)
		{
			gameManagerComponents.Remove(gameManagerComponentBehaviour);
		}

		private void OnValidate()
		{
			if (!resetListOnValidate)
				return;
			gameManagerComponents.Clear();
			GameManagerComponentBehaviour[] gameManagerComponentsInScene;
			gameManagerComponentsInScene = GameObject.FindObjectsOfType<GameManagerComponentBehaviour>();
			foreach (GameManagerComponentBehaviour component in gameManagerComponentsInScene)
			{
				gameManagerComponents.Add(component);
			}
		}
	}
}