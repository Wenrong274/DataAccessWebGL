using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace WebGLAccess
{
    public class DataAccess
    {
        [DllImport("__Internal")]
        private static extern void SyncFiles();
        [DllImport("__Internal")]
        private static extern void ReadFiles();
        [DllImport("__Internal")]
        private static extern void WindowAlert(string message);

        public static void Save(string FileName, Byte[] bytes)
        {
            string dataPath = string.Format("{0}/{1}.dat", Application.persistentDataPath, FileName);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream;

            try
            {
                if (File.Exists(dataPath))
                {
                    File.WriteAllText(dataPath, string.Empty);
                    fileStream = File.Open(dataPath, FileMode.Open);
                }
                else
                {
                    fileStream = File.Create(dataPath);
                }
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Close();

                if (Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    SyncFiles();
                }
            }
            catch (Exception e)
            {
                PlatformSafeMessage("Failed to Save: " + e.Message);
            }
        }

        public static byte[] Load(string FileName)
        {
            byte[] result = null;
            string dataPath = string.Format("{0}/{1}.dat", Application.persistentDataPath, FileName);

            if (File.Exists(dataPath))
                result = File.ReadAllBytes(dataPath);

            if (Application.platform == RuntimePlatform.WebGLPlayer)
                ReadFiles();

            return result;
        }

        private static void PlatformSafeMessage(string message)
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                WindowAlert(message);
            }
            else
            {
                Debug.Log(message);
            }
        }
    }
}
