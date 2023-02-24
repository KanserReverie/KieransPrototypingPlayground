using System.IO;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GameManagerSingleton.GameManagerComponents
{
    public class PlayerSaveDataManager : GameManagerComponentBehaviour
    {
        [SerializeField] private PlayerSaveData playerSaveData = new PlayerSaveData();
        private string saveFileLocation;
        
        private void Awake()
        {
            saveFileLocation = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "/playerSaveData.json";
        }
        
        public void SavePlayerData()
        {
            GetPlayerData();
            string savePath = saveFileLocation;
            Debug.Log($"Saving Player Data @:{savePath}");
            string json = JsonUtility.ToJson(playerSaveData);
            using StreamWriter writer = new StreamWriter(saveFileLocation);
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
            using StreamReader reader = new StreamReader(saveFileLocation);
            string json = reader.ReadToEnd();

            playerSaveData = JsonUtility.FromJson<PlayerSaveData>(json);
            
            GameObject playerInScene = GameObject.FindGameObjectWithTag("Player");
            playerInScene.transform.position = playerSaveData.location;
            playerInScene.transform.rotation = playerSaveData.rotation;
            Rigidbody playerRigidbody = playerInScene.GetComponentInChildren<Rigidbody>();
            playerRigidbody = playerSaveData.rigidbody;
        }

        private void GetPlayerData()
        {
            GameObject playerInScene = GameObject.FindGameObjectWithTag("Player");
            if (playerInScene == null)
                Debug.Log("Sorry, cant find a GameObject with a 'Player' tag");
            else
            {
                playerSaveData.location = playerInScene.transform.position;
                playerSaveData.rotation = playerInScene.transform.rotation;
                playerSaveData.rigidbody = playerInScene.GetComponentInChildren<Rigidbody>();
            }
        }
    }
}
