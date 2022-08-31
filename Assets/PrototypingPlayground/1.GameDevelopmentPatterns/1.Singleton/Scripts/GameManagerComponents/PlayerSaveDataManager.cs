using System.IO;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns._1.Singleton.GameManagerComponents
{
    public class PlayerSaveDataManager : GameManagerComponentBehaviour
    {
        [SerializeField] private PlayerSaveData _playerSaveData = new PlayerSaveData();
        private string _saveFileLocation;
        
        private void Awake()
        {
            _saveFileLocation = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "/playerSaveData.json";
        }
        
        public void SavePlayerData()
        {
            GetPlayerData();
            string savePath = _saveFileLocation;
            Debug.Log($"Saving Player Data @:{savePath}");
            string json = JsonUtility.ToJson(_playerSaveData);
            using StreamWriter writer = new StreamWriter(_saveFileLocation);
            writer.Write(json);
        }

        private void OnGUI()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Singleton_Gameplay")
            {
                GUILayout.BeginArea(new Rect(0, -Screen.height/2.1f, Screen.width, Screen.height));
                GUILayout.FlexibleSpace();
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();

                if(GUILayout.Button("Save Player"))
                {
                    SavePlayerData();
                }
                if(GUILayout.Button("Load Player"))
                {
                    LoadPlayerData();
                }
                
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.EndArea();
            }
        }

        public void LoadPlayerData()
        {
            using StreamReader reader = new StreamReader(_saveFileLocation);
            string json = reader.ReadToEnd();

            _playerSaveData = JsonUtility.FromJson<PlayerSaveData>(json);
            
            GameObject playerInScene = GameObject.FindGameObjectWithTag("Player");
            playerInScene.transform.position = _playerSaveData.location;
            playerInScene.transform.rotation = _playerSaveData.rotation;
            Rigidbody playerRigidbody = playerInScene.GetComponentInChildren<Rigidbody>();
            playerRigidbody = _playerSaveData.rigidbody;
        }

        private void GetPlayerData()
        {
            GameObject playerInScene = GameObject.FindGameObjectWithTag("Player");
            if (playerInScene == null)
                Debug.Log("Sorry, cant find a GameObject with a 'Player' tag");
            else
            {
                _playerSaveData.location = playerInScene.transform.position;
                _playerSaveData.rotation = playerInScene.transform.rotation;
                _playerSaveData.rigidbody = playerInScene.GetComponentInChildren<Rigidbody>();
            }
        }
    }
}
