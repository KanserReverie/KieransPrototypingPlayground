using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.MuteAudio
{
    public class MuteAudioFunctions : MonoBehaviour
    {
        public void MuteAudioToggle(bool makeMuted)
        {
            if (makeMuted)
            {
                AudioListener.volume = 0;
            }
            else
            {
                AudioListener.volume = 1;
            }
        }
    }
}
