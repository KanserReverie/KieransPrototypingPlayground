using System;
using System.Collections;
using TMPro;
using UnityEngine;
namespace PrototypingPlayground.EventBus.PlatformerEventBus
{
    public class GameCountDownTimer : MonoBehaviour
    {
        [SerializeField, Range(1,5)] private int countDownTimerStart = 3;
        [SerializeField] private TextMeshProUGUI countDownText;
        [SerializeField] private GameObject readyPanel;
        
        private int _currentCountDownTimer;

        private PlatformerGameManagerEventBus _platformerGameManagerEventBus;

        private void Start()
        {
            FindEventBusInScene();
            
            _currentCountDownTimer = countDownTimerStart;
            StartCoroutine(StartCountDown());
        }
        
        private void FindEventBusInScene()
        {
            if(_platformerGameManagerEventBus == null)
                _platformerGameManagerEventBus = FindObjectOfType<PlatformerGameManagerEventBus>();
            
            if(_platformerGameManagerEventBus == null)
                Debug.Log("Please add a PlatformerGameManagerEventBus to Scene!!");
        }
        
        private IEnumerator StartCountDown()
        {
            do
            {
                countDownText.text = ($"Game starts in {_currentCountDownTimer}");
                _currentCountDownTimer--;
                yield return new WaitForSeconds(1);
            } while (_currentCountDownTimer > 0);

            if (_platformerGameManagerEventBus != null)
            {
                _platformerGameManagerEventBus.PublishEvent(PlatformerEvents.START);
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
