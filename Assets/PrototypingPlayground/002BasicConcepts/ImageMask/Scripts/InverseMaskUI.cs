using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace PrototypingPlayground._002BasicConcepts.ImageMask
{
    public class InverseMaskUI : Image
    {
        public override Material materialForRendering
        {
            get
            {
                Material material = new Material(base.materialForRendering);
                material.SetInt("_StencilComp", (int) CompareFunction.NotEqual);
                return material;
            }
        }
    }
}