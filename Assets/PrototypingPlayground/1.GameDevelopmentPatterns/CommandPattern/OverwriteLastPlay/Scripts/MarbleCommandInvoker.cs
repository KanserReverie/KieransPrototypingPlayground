using System.Collections.Generic;
using System.Linq;
using PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.OverwriteLastPlay.Scripts.Commands;
using PrototypingPlayground.UsefulScripts;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.OverwriteLastPlay.Scripts
{
    public class MarbleCommandInvoker : MonoBehaviour
    {
        private bool weAreRecording;
        private bool weAreReplaying;
        private bool gameHasStarted;
        private float currentGameTimer;

        private int commandCount;

        private PlayerInput playerInput;
        private MarbleController marbleController;
        private TMP_Text timerTMPText;
        private TMP_Text statusTMPText;
        private float startingGameTimer = 10f;
        
        private SortedList<float, AbstractMarbleCommand> recordedCommands = new SortedList<float, AbstractMarbleCommand>();
        private float playTime;
        private bool jumpInput;
        private Vector2 horizontalMovementInput;

        public void Init(PlayerInput _playerInput, MarbleController _marbleController, TMP_Text _timerTMPText, TMP_Text _statusTMPText, float _startingGameTimer)
        {
            playerInput = _playerInput;
            marbleController = _marbleController;
            timerTMPText = _timerTMPText;
            statusTMPText = _statusTMPText;
            startingGameTimer = _startingGameTimer;
        }

        private void FixedUpdate()
        {
            if (!gameHasStarted) return;
            
            if (weAreReplaying)
            {
                if (currentGameTimer > 0 && recordedCommands.Any())
                {
                    if ((playTime + (0.5 * Time.fixedDeltaTime)) > recordedCommands.Keys[commandCount])
                    {
                        recordedCommands.Values[commandCount].ExecuteCommand();
                        commandCount++;
                    }
                }
            }
            HandleTime();
        }
        
        public void ReplaySimulation()
        {
            currentGameTimer = startingGameTimer;
            timerTMPText.text = ($"{currentGameTimer}");
            statusTMPText.text = ($"Replaying");
            new Respawn(marbleController).ExecuteCommand();
            playTime = 0f;
            weAreRecording = false;
            weAreReplaying = true;
            recordedCommands.Reverse();
        }
        
        public void PauseGameBeforeRecording()
        {
            currentGameTimer = startingGameTimer;
            timerTMPText.text = ($"{currentGameTimer}");
            statusTMPText.text = ($"");
            
            playerInput.actions.Disable();
            weAreRecording = false;
            gameHasStarted = false;
            playTime = 0;
            recordedCommands.Add(playTime, new Respawn(marbleController));
            Time.timeScale = 0;
        }

        public void StartSimulation()
        {
            Time.timeScale = 1;
            statusTMPText.text = ($"Recording");
            playerInput.actions.Enable();
            gameHasStarted = true;
            weAreRecording = true;
            HandleTime();
        }
        
        private void HandleTime()
        {
            timerTMPText.text = ($"{currentGameTimer}");
            playTime += Time.fixedDeltaTime;

            if (currentGameTimer > 0)
            {
                currentGameTimer -= Time.fixedDeltaTime;
            }
            
            if (currentGameTimer <= 0)
            {
                currentGameTimer = 0;
                if (!weAreRecording && !weAreReplaying)
                {
                    CommonlyUsedStaticMethods.QuitGame();
                }
                ReplaySimulation();
            }
        }

        public void ExecuteCommand(AbstractMarbleCommand _marbleCommandToRun)
        {
            _marbleCommandToRun.ExecuteCommand();
            if (weAreRecording)
            {
                if (recordedCommands.ContainsKey(playTime))
                {
                    // This is just encase there is already an input at this frame. 
                    recordedCommands.Add(playTime + (Time.fixedDeltaTime / 4), _marbleCommandToRun);
                }
                else
                {
                    recordedCommands.Add(playTime, _marbleCommandToRun);
                }
            }
            if (weAreReplaying)
            {
                weAreReplaying = false;
                statusTMPText.text = ($"");
            }
        }
    }
}
