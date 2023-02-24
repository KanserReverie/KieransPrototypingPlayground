// Creator: Kieran
// Creation Time: 2022/06/11 10:25

using System;
using UnityEngine;

namespace PrototypingPlayground._001GameDevelopmentPatterns._001Singleton.GameManagerSingleton.GameManagerComponents
{
	public class TimeManager : GameManagerComponentBehaviour
	{
		private DateTime sessionStartTime;
		private DateTime sessionEndTime;
		private void Start()
		{
			sessionStartTime = DateTime.Now;
			Debug.Log($"Session started @: {sessionStartTime}");
		}

		private void OnApplicationQuit()
		{
			sessionEndTime = DateTime.Now;
			TimeSpan sessionTimespan = sessionEndTime.Subtract(sessionStartTime);

			Debug.Log($"Session timespan was: {sessionTimespan}");
			Debug.Log($"Session ended @: {sessionEndTime}");
		}
	}
}