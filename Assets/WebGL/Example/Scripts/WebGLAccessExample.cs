using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace WebGLAccess.Example
{
    public class WebGLAccessExample : MonoBehaviour
    {
        [SerializeField] private RawImage image;
        [SerializeField] private Texture2D texture;
        string fileName = "webglTest";

        public void Save()
        {
            DataAccess.Save(fileName, texture.EncodeToPNG());
        }

        public void Load()
        {
            Texture2D tex = new Texture2D(1, 1);
            byte[] bytes = DataAccess.Load(fileName);
            tex.LoadImage(bytes);
            image.texture = tex;
            Texture2D.DestroyImmediate(tex, true);
        }

        public void Clean()
        {
            image.texture = null;
        }
    }
}
