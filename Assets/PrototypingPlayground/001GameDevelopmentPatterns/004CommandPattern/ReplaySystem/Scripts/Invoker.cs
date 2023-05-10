using System.Collections.Generic;
using System.Linq;
using PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem.Commands;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._004CommandPattern.ReplaySystem
{
    public class Invoker : MonoBehaviour
    {
        private bool isRecording;
        private bool isReplaying;

        private float recordTime;
        private float replayTime;

        private SortedList<float, Command> recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command)
        {
            command.Execute();

            if (isRecording)
            {
                recordedCommands.Add(recordTime, command);
            }

            Debug.Log($"Recorded at: {recordTime}");
            Debug.Log($"Recorded Command: {command}");
        }

        public void Record()
        {
            isRecording = true;
            recordTime = 0.0f;
        }

        public void Replay()
        {
            isReplaying = true;
            replayTime = 0.0f;

            if (recordedCommands.Count <= 0)
            {
                Debug.Log("No Commands to replay!");
            }
        }

        private void FixedUpdate()
        {
            if (isRecording)
            {
                recordTime += Time.fixedDeltaTime;
            }

            if (isReplaying)
            {
                replayTime += Time.fixedDeltaTime;
                if (recordedCommands.Any())
                {
                    if (Mathf.Approximately( recordedCommands.Keys[0],replayTime))
                    {
                        recordedCommands.Values[0].Execute();
                        
                        Debug.Log($"Replay Time: {replayTime}");
                        Debug.Log($"Replay Action: {recordedCommands.Values[0]}");

                        recordedCommands.RemoveAt(0);
                    }
                }
                else
                {
                    isReplaying = false;
                }
            }
        }
    }
}
