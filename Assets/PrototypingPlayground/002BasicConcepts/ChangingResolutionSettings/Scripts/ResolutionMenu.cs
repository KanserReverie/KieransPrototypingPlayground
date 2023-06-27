using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.ChangingResolutionSettings
{
    public class ResolutionMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resolutionDropdown;

        private Resolution[] resolutions;

        private void Start()
        {
            // Get available screen resolutions
            resolutions = Screen.resolutions;

            // Clear existing options from the dropdown
            resolutionDropdown.ClearOptions();

            // Create a list of resolution options as strings
            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                // Check if the current resolution matches the screen's current resolution
                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            // Add the resolution options to the dropdown
            resolutionDropdown.AddOptions(options);

            // Set the current resolution as the selected option in the dropdown
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
    }
}