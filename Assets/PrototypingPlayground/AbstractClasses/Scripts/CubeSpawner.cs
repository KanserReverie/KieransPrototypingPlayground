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
            GameObject SpawnableCube = new GameObject("Spawnable Cube");
            GameObject cube =  Instantiate(
                GameObject.CreatePrimitive(PrimitiveType.Cube), 
                this.transform.position, 
                Random.rotation);
            cube.AddComponent<SpawnableCube>().Setup(scale, lifeSpan);
        }
        private float GetLifeSpan()
        {
            float lifeSpan = 1;
            if ((lifeSpanInputField.text == "") || string.IsNullOrEmpty(lifeSpanInputField.text))
            {
                Debug.Log("Please input a LifeSpan, using '1' for now");
            }
            else
            {
                Debug.Log(lifeSpanInputField.text);
                Debug.Log(lifeSpanInputField.text.Length);
                if (float.TryParse(lifeSpanInputField.text.Replace(".",","), out float _lifeSpan))
                {
                    Debug.Log("parse OK");
                    lifeSpan = _lifeSpan;
                }
                else
                {
                    Debug.Log("parse KO");
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
                Debug.Log("Please input a Scale, using '1' for now");
            }
            else
            {
                Debug.Log(scaleInputField.text);
                Debug.Log(scaleInputField.text.Length);
                if (float.TryParse(scaleInputField.text.Replace(".",","), out float _scale))
                {
                    Debug.Log("parse OK");
                    scale = _scale;
                }
                else
                {
                    Debug.Log("parse KO");
                    scale = 0;
                }
            }
            return scale;
        }
    }
}
