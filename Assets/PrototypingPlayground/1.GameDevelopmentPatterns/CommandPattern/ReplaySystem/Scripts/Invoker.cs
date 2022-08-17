using System.Collections.Generic;
using System.Linq;
using PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.ReplaySystem.Scripts.Commands;
using UnityEngine;
namespace PrototypingPlayground._1.GameDevelopmentPatterns.CommandPattern.ReplaySystem.Scripts
{
    public class Invoker : MonoBehaviour
    {
        private bool _isRecording;
        private bool _isReplaying;

        private float _recordTime;
        private float _replayTime;

        private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        public void ExecuteCommand(Command command)
        {
            command.Execute();

            if (_isRecording)
            {
                _recordedCommands.Add(_recordTime, command);
            }

            Debug.Log($"Recorded at: {_recordTime}");
            Debug.Log($"Recorded Command: {command}");
        }

        public void Record()
        {
            _isRecording = true;
            _recordTime = 0.0f;
        }

        public void Replay()
        {
            _isReplaying = true;
            _replayTime = 0.0f;

            if (_recordedCommands.Count <= 0)
            {
                Debug.Log("No Commands to replay!");
            }
        }

        private void FixedUpdate()
        {
            if (_isRecording)
            {
                _recordTime += Time.fixedDeltaTime;
            }

            if (_isReplaying)
            {
                _replayTime += Time.fixedDeltaTime;
                if (_recordedCommands.Any())
                {
                    if (Mathf.Approximately( _recordedCommands.Keys[0],_replayTime))
                    {
                        _recordedCommands.Values[0].Execute();
                        
                        Debug.Log($"Replay Time: {_replayTime}");
                        Debug.Log($"Replay Action: {_recordedCommands.Values[0]}");

                        _recordedCommands.RemoveAt(0);
                    }
                }
                else
                {
                    _isReplaying = false;
                }
            }
        }
    }
}
