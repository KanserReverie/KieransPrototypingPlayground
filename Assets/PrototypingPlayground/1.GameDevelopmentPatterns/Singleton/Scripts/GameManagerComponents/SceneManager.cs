// Creator: 
// Creation Time: 2022/06/11 10:28
using System;
using PrototypingPlayground.UsefulScripts;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.Singleton.Scripts.GameManagerComponents
{
	public class SceneManager : GameManagerComponentBehaviour
	{
		private enum ActiveSingletonScene { Lobby,Gameplay, NoSingletonScene }
		private ActiveSingletonScene _activeSingletonScene;
		[SerializeField] private string lobbySceneName = "Singleton_Lobby";
		[SerializeField] private string gameplaySceneName = "Singleton_Gameplay";

		private void Start()
		{
			Debug.Log($"Active Scene Name = {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}");

			if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == lobbySceneName) 
				_activeSingletonScene = ActiveSingletonScene.Lobby;
			else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == gameplaySceneName) 
				_activeSingletonScene = ActiveSingletonScene.Gameplay;
			else 
				_activeSingletonScene = ActiveSingletonScene.NoSingletonScene;
		}
		private void OnGUI()
		{
			switch (_activeSingletonScene)
			{
				case ActiveSingletonScene.Lobby:
					if(GUILayout.Button("Open 'Singleton_Gameplay' Scene"))
					{
						UnityEngine.SceneManagement.SceneManager.LoadScene("Singleton_Gameplay");
						_activeSingletonScene = ActiveSingletonScene.Gameplay;
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