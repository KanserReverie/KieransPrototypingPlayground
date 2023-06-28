using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypingPlayground._004QuickPrototypes.TuplesAndLinq.Scripts
{
    public class ExampleColorFlash : MonoBehaviour
    {
        private List<(Image, Color)> imagesAndColors;

        public Color colorToFlash;
        
        public void Update()
        {
            // Flash images between their original colors and the flash color.
            for (int i = 0; i < imagesAndColors.Count; i++)
            {
                var val = imagesAndColors[i];
                val.Item1.color = Color.Lerp(
                    a: val.Item2,
                    b: colorToFlash, 
                    t: Time.time
                );
            }
        }

 

        public void Add(Image image)
        {
            if (imagesAndColors.Any(imageAndColor => imageAndColor.Item1 == image))
                return;

 

            List<Image> redImages = imagesAndColors
                .Where(it => it.Item2 == Color.red)
                .Select(it => it.Item1)
                .ToList();
            
            // Add image to list
        }
    }
}
