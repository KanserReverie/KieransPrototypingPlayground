// Creator: Kieran
// Creation Time: 2022/06/11 10:25
using System;
using UnityEngine;
namespace PrototypingPlayground.GameDevelopmentPatterns.Singleton.GameManagerComponents
{
	public class TimeManager : GameManagerComponentBehaviour
	{
		private DateTime _sessionStartTime;
		private DateTime _sessionEndTime;
		private void Start()
		{
			_sessionStartTime = DateTime.Now;
			Debug.Log($"Session started @: {_sessionStartTime}");
		}

		private void OnApplicationQuit()
		{
			_sessionEndTime = DateTime.Now;
			TimeSpan sessionTimespan = _sessionEndTime.Subtract(_sessionStartTime);

			Debug.Log($"Session timespan was: {sessionTimespan}");
			Debug.Log($"Session ended @: {_sessionEndTime}");
		}
	}
}