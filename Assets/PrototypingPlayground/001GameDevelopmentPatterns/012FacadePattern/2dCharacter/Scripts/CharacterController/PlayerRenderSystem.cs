using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter.CharacterController
{
    public class PlayerRenderSystem : MonoBehaviour
    {
        public void TurnOffPlayerRenders()
        {
            MeshRenderer[] playerRenders = GetComponentsInChildren<MeshRenderer>();
            if (playerRenders != null)
            {
                foreach (MeshRenderer render in playerRenders)
                {
                    if (render != null)
                    {
                        render.enabled = false;
                    }
                }
            }
        }
        
        public void TurnOnPlayerRenders()
        {
            MeshRenderer[] playerRenders = GetComponentsInChildren<MeshRenderer>();
            if (playerRenders != null)
            {
                foreach (MeshRenderer render in playerRenders)
                {
                    if (render != null)
                    {
                        render.enabled = true;
                    }
                }
            }
        }
    }
}
