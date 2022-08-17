using PrototypingPlayground.UsefulScripts;
using UnityEngine;
using UnityEngine.UI;
namespace PrototypingPlayground._4.QuickPrototypes.ControllerMainMenu.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuGameObject;
        [Header("Main Menu")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private Button mainMenuFirstSelectedButton;
        [SerializeField] private Button playButton, settingsButton, quitButton;
        [Header("Settings Menu")]
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Button settingsMenuFirstSelectedButton;
        [SerializeField] private Button backButton, saveButton;

        private void OnEnable()
        {
            PauseTheGame();
            mainMenuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            mainMenuFirstSelectedButton.Select();

            playButton.onClick.AddListener(OnPlay);
            quitButton.onClick.AddListener(OnQuit);
            settingsButton.onClick.AddListener(OnOpenSettings);
            backButton.onClick.AddListener(OnBack);
            saveButton.onClick.AddListener(OnSave);
        }
        private void OnSave() => Debug.Log("Saved settings");
        
        private void OnBack()
        {
            mainMenuPanel.SetActive(true);
            settingsPanel.SetActive(false);
            mainMenuFirstSelectedButton.Select();
        }
        
        private void OnOpenSettings()
        {
            mainMenuPanel.SetActive(false);
            settingsPanel.SetActive(true);
            settingsMenuFirstSelectedButton.Select();
        }

        private void OnPlay()
        {
            UnPauseTheGame();
            mainMenuGameObject.gameObject.SetActive(false);
        }
        
        private void OnQuit() => CommonlyUsedStaticMethods.QuitGame();

        private void PauseTheGame() => Time.timeScale = 0;
        private void UnPauseTheGame() => Time.timeScale = 1;
    }
}
