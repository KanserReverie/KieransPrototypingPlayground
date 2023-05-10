using System.Collections.Generic;
using System.Linq;
using PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem.Commands;
using PrototypingPlayground.UsefulScripts;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.MarbleReplaySystem
{
    public class MarbleCommandInvoker : MonoBehaviour
    {
        private bool weAreRecording;
        public bool WeAreReplaying { get; private set; }
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

        public void Init(PlayerInput playerInput, MarbleController marbleController, TMP_Text timerTMPText, TMP_Text statusTMPText, float startingGameTimer)
        {
            this.playerInput = playerInput;
            this.marbleController = marbleController;
            this.timerTMPText = timerTMPText;
            this.statusTMPText = statusTMPText;
            this.startingGameTimer = startingGameTimer;
        }

        private void Start()
        {
            recordedCommands = new SortedList<float, AbstractMarbleCommand>();
        }

        private void FixedUpdate()
        {
            if (!gameHasStarted) return;

            if (WeAreReplaying)
            {
                if (currentGameTimer > 0 && recordedCommands.Any())
                {
                    if ((playTime + (0.5 * Time.fixedDeltaTime)) >= recordedCommands.Keys[commandCount])
                    {
                        recordedCommands.Values[commandCount].ExecuteCommand();
                        if (commandCount+1 < recordedCommands.Count)
                        {
                            commandCount++;
                        }
                    }
                }
            }

            HandleTime();
        }

        private void ReplaySimulation()
        {
            currentGameTimer = startingGameTimer;
            timerTMPText.text = ($"{currentGameTimer}");
            statusTMPText.text = ($"Replaying");
            new Respawn(marbleController).ExecuteCommand();
            playTime = 0f;
            weAreRecording = false;
            WeAreReplaying = true;
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
                if (weAreRecording)
                {
                    ReplaySimulation();
                }
                else
                {
                    CommonlyUsedStaticMethods.QuitGame();
                }
            }
        }

        public void ExecuteCommand(AbstractMarbleCommand marbleCommandToRun)
        {
            marbleCommandToRun.ExecuteCommand();
            if (weAreRecording)
            {
                if (recordedCommands.ContainsKey(playTime))
                {
                    // This is just encase there is already an input at this frame. 
                    recordedCommands.Add(playTime + (Time.fixedDeltaTime / 4), marbleCommandToRun);
                }
                else
                {
                    recordedCommands.Add(playTime, marbleCommandToRun);
                }
            }
            if (WeAreReplaying)
            {
                WeAreReplaying = false;
                statusTMPText.text = ($"");
            }
        }
    }
}
