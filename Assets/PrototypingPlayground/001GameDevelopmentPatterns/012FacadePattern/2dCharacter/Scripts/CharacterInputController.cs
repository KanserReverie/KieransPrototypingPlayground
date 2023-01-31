using System;
using UnityEngine;
namespace PrototypingPlayground._001GameDevelopmentPatterns._012FacadePattern._2dCharacter
{
    public class CharacterInputController : MonoBehaviour
    {
        private CharacterControllerFacade characterControllerFacade;
        private void Start()
        {
            characterControllerFacade = GetComponentInChildren<CharacterControllerFacade>();
            
            characterControllerFacade.SpawnPlayer();
        }
    }
}
