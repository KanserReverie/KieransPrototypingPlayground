using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.LockWindowedResolution
{
    public class AspectRatioHandler : MonoBehaviour
    {
        public float targetAspectRatio = 16f / 9f;
        private int lastScreenWidth;
        private int lastScreenHeight;

        void Start()
        {
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
            SetAspectRatio(targetAspectRatio);
        }

        void Update()
        {
            // Check if the screen resolution has changed
            if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
            {
                lastScreenWidth = Screen.width;
                lastScreenHeight = Screen.height;
                SetAspectRatio(targetAspectRatio);
            }
        }

        void SetAspectRatio(float aspectRatio)
        {
            // Get the current window size
            int width = Screen.width;
            int height = Screen.height;

            // Calculate the target height based on the current width and desired aspect ratio
            int targetHeight = Mathf.RoundToInt(width / aspectRatio);

            // If the current height is greater than the target height, adjust the width instead
            if (height > targetHeight)
            {
                height = targetHeight;
            }
            else
            {
                width = Mathf.RoundToInt(height * aspectRatio);
            }

            // Set the new resolution while maintaining the windowed or fullscreen mode
            Screen.SetResolution(width, height, Screen.fullScreen);
        }
    }
}
