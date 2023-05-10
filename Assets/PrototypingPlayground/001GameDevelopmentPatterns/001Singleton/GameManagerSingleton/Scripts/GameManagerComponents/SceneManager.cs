// Creator: 
// Creation Time: 2022/06/11 10:28

using System;
using UnityEngine;

using PrototypingPlayground.UsefulScripts;

namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GameManagerSingleton.GameManagerComponents
{
	public class SceneManager : GameManagerComponentBehaviour
	{
		private enum ActiveSingletonScene { Lobby,Gameplay, NoSingletonScene }
		private ActiveSingletonScene activeSingletonScene;
		[SerializeField] private string lobbySceneName = "Singleton_Lobby";
		[SerializeField] private string gameplaySceneName = "Singleton_Gameplay";

		private void Start()
		{
			Debug.Log($"Active Scene Name = {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}");

			if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == lobbySceneName) 
				activeSingletonScene = ActiveSingletonScene.Lobby;
			else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == gameplaySceneName) 
				activeSingletonScene = ActiveSingletonScene.Gameplay;
			else 
				activeSingletonScene = ActiveSingletonScene.NoSingletonScene;
		}
		private void OnGUI()
		{
			switch (activeSingletonScene)
			{
				case ActiveSingletonScene.Lobby:
					if(GUILayout.Button("Open 'Singleton_Gameplay' Scene"))
					{
						UnityEngine.SceneManagement.SceneManager.LoadScene($"Singleton_Gameplay");
						activeSingletonScene = ActiveSingletonScene.Gameplay;
					}
					break;
				case ActiveSingletonScene.Gameplay:
					break;
				case ActiveSingletonScene.NoSingletonScene:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			if(GUILayout.Button("End Session"))
			{
				CommonlyUsedStaticMethods.QuitGame();
			}
		}
	}
}