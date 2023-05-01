using UnityEngine;

namespace PrototypingPlayground._002BasicConcepts.UISlider
{
    public class MovingImage : MonoBehaviour
    {
        private RectTransform imageLocation;
        [SerializeField] private float imageHeight = 100;

        private void Start()
        {
            imageLocation = GetComponent<RectTransform>();
        }

        private void Update()
        {
            // This will move the location equal to what image height is.
            imageLocation.position = new Vector3(imageLocation.position.x, imageHeight, imageLocation.position.z);
        }

        // This is attached to the slider.
        public void ChangeImageHeight(float _changedHeight)
        {
            imageHeight = _changedHeight;
        }
    }
}
