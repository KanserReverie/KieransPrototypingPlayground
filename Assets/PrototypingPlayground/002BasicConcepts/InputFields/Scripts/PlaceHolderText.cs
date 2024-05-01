using System;
using PrototypingPlayground.UsefulScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.InputFields
{
    public class PlaceHolderText : MonoBehaviour
    {
        public TMP_InputField inputField;
        string hint = "k--t--n";
        string correctAnswer = "kitten";
        string winMessage = "Correct!";
        public Button resetSceneButton;
        public Button showHintButton;

        public void OnEnable()
        {
            resetSceneButton.onClick.RemoveAllListeners();
            resetSceneButton.onClick.AddListener(ResetScene);
            showHintButton.onClick.RemoveAllListeners();
            showHintButton.onClick.AddListener(ShowHint);
        }

        private void Update()
        {
            CheckIfCorrect();
        }

        private void CheckIfCorrect()
        {
            if (inputField.text.Equals(correctAnswer))
            {
                inputField.textComponent.color = Color.green;
                inputField.text = winMessage;
                inputField.interactable = false;
            }
        }

        private void ShowHint()
        {
            if (inputField.text.Equals(winMessage)) return;
            inputField.text = "";
            inputField.placeholder.color = Color.grey;
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = hint;
        }

        private void ResetScene()
        {
            CommonlyUsedStaticMethods.ResetCurrentScene();
        }
    }
}