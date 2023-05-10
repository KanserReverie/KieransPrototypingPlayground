using System.Collections;
using TMPro;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._003EventBus.PlatformerEventBus
{
    public class CountDownTimer : MonoBehaviour
    {
        [SerializeField, Range(1,5)] private int countDownTimerStart = 3;
        [SerializeField] private TextMeshProUGUI countDownText;
        [SerializeField] private GameObject readyPanel;
        
        private int currentCountDownTimer;

        private GameManagerEventBus gameManagerEventBus;

        private void Start()
        {
            gameManagerEventBus = GameManagerEventBus.FindEventBusInScene();
            
            currentCountDownTimer = countDownTimerStart;
            StartCoroutine(StartCountDown());
        }
        
        private IEnumerator StartCountDown()
        {
            do
            {
                countDownText.text = ($"Game starts in {currentCountDownTimer}");
                currentCountDownTimer--;
                yield return new WaitForSeconds(1);
            } while (currentCountDownTimer > 0);

            if (gameManagerEventBus != null)
            {
                gameManagerEventBus.PublishEvent(PlatformerEvents.Start);
                countDownText.text = ("Go!");
                yield return new WaitForSeconds(1);
                readyPanel.SetActive(false);
            }
            else
            {
                Debug.Log("Please add a PlatformerGameManagerEventBus to Scene to go any further!!");
            }
        }
    }
}
