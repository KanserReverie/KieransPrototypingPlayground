using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using PrototypingPlayground.CommandPattern.OverwriteLastPlay.Commands;
using PrototypingPlayground.UsefulScripts;

namespace PrototypingPlayground.CommandPattern.OverwriteLastPlay
{
    public class MarbleCommandInvoker : MonoBehaviour
    {
        private bool weAreRecording;
        private bool weAreReplaying;
        private bool gameHasStarted;
        private float currentGameTimer;

        private PlayerInput playerInput;
        private MarbleController marbleController;
        private TMP_Text timerTMPText;
        private float startingGameTimer = 10f;
        
        private SortedList<float, AbstractMarbleCommand> recordedCommands = new SortedList<float, AbstractMarbleCommand>();
        private float playTime;
        private bool jumpInput;
        private Vector2 horizontalMovementInput;

        public void Init(PlayerInput _playerInput, MarbleController _marbleController, TMP_Text _timerTMPText, float _startingGameTimer)
        {
            playerInput = _playerInput;
            marbleController = _marbleController;
            timerTMPText = _timerTMPText;
            startingGameTimer = _startingGameTimer;
        }

        private void FixedUpdate()
        {
            if (!gameHasStarted) return;
            
            if (weAreReplaying)
            {
                if (currentGameTimer > 0)
                {
                    Debug.Log($"recordedCommands.Keys[0] = {recordedCommands[0]}");
                    if ((playTime + (0.5 * Time.fixedDeltaTime)) < recordedCommands.Keys[0])
                    {
                        recordedCommands.Values[0].ExecuteCommand();
                        recordedCommands.RemoveAt(0);
                        
                        if ((playTime + (0.5 * Time.fixedDeltaTime)) < recordedCommands.Keys[0])
                        {
                            recordedCommands.Values[0].ExecuteCommand();
                            recordedCommands.RemoveAt(0);
                        }
                    }
                }
            }
            HandleTime();
        }
        
        public void ReplaySimulation()
        {
            currentGameTimer = startingGameTimer;
            timerTMPText.text = ($"{currentGameTimer}");
            playerInput.actions.Disable();
            new Respawn(marbleController).ExecuteCommand();
            playTime = 0f;
            weAreRecording = false;
            weAreReplaying = true;
            recordedCommands.Reverse();
            
            for (int i = 0; i < recordedCommands.Count; i++)
            {
                Debug.Log($"recordedCommands[i] = {recordedCommands[i]}");
            }
        }
        
        public void PauseGameBeforeRecording()
        {
            currentGameTimer = startingGameTimer;
            timerTMPText.text = ($"{currentGameTimer}");
            
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
                if (weAreReplaying)
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
                
                recordedCommands.Add(playTime, _marbleCommandToRun);
            }
        }
    }
}
