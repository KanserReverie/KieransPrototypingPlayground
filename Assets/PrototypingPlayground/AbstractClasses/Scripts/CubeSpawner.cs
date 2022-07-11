using TMPro;
using UnityEngine;
namespace PrototypingPlayground.AbstractClasses
{
    public class CubeSpawner : MonoBehaviour
    {
        public TMP_InputField scaleInputField;
        public TMP_InputField lifeSpanInputField;
        
        public void SpawnCube()
        {
            float scale = GetScale();
            float lifeSpan = GetLifeSpan();
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = this.transform.position;
            cube.transform.rotation = Random.rotation;
            cube.AddComponent<SpawnableCube>().Setup(scale, lifeSpan);
        }
        private float GetLifeSpan()
        {
            float lifeSpan = 1;
            if ((lifeSpanInputField.text == "") || string.IsNullOrEmpty(lifeSpanInputField.text))
            {
                return lifeSpan;
            }
            else
            {
                Debug.Log(lifeSpanInputField.text);
                Debug.Log(lifeSpanInputField.text.Length);
                if (float.TryParse(lifeSpanInputField.text.Replace(".",","), out float _lifeSpan))
                {
                    lifeSpan = _lifeSpan;
                }
                else
                {
                    lifeSpan = 0;
                }
            }
            return lifeSpan;
        }
        private float GetScale()
        {
            float scale = 1;
            if ((scaleInputField.text == "") || string.IsNullOrEmpty(scaleInputField.text))
            {
                return scale;
            }
            else
            {
                Debug.Log(scaleInputField.text);
                Debug.Log(scaleInputField.text.Length);
                if (float.TryParse(scaleInputField.text.Replace(".",","), out float _scale))
                {
                    scale = _scale;
                }
                else
                {
                    scale = 0;
                }
            }
            return scale;
        }
    }
}
