using UnityEngine;
using System.Collections;

namespace GraphWindow
{
    public class LineMaterial
    {
        static Material material;

        public static Material Material
        {
            get
            {
                if( null != material )
                {
                    return material;
                }


                Shader shader = Shader.Find("Hidden/Internal-Colored");
                material = new Material(shader);
                material.hideFlags = HideFlags.HideAndDontSave;

                material.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
                material.SetInt("_ZWrite", 0);
                // alpha blending
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

                return material;
            }
        }
    }
}