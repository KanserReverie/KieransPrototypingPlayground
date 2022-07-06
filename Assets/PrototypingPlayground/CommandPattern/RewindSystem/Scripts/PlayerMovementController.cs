using System;
using System.Collections.Generic;
using UnityEngine;
namespace PrototypingPlayground.CommandPattern.RewindSystem.Scripts
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private List<Material> listOfMaterials;
        private int _currentMaterialIndex;

        private void Start()
        {
            _currentMaterialIndex = 0;
            GetComponent<MeshRenderer>().material = listOfMaterials[_currentMaterialIndex];
        }
        public void ChangeColour()
        {
            _currentMaterialIndex++;
            if (_currentMaterialIndex >= listOfMaterials.Count)
            {
                _currentMaterialIndex = 0;
            }
            GetComponent<MeshRenderer>().material = listOfMaterials[_currentMaterialIndex];
        }
        private void OnGUI()
        {
            if(GUILayout.Button("Change Colour")) ChangeColour();
        }
        // public void Move(Direction)
    }
}
