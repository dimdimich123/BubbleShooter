using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Infrastructure.Serialization
{
    public static class BinarySerialization
    {
        public static void SerializeData<T>(string path, T data)
        {
            CheckDirectory();

            string pathToSettings = path.Contains(Application.persistentDataPath) ? path : Application.persistentDataPath + path;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(pathToSettings, FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }
        }

        public static T DeserializeData<T>(string path)
        {
            CheckDirectory();

            string pathToSettings = path.Contains(Application.persistentDataPath) ? path : Application.persistentDataPath + path;
            BinaryFormatter formatter = new BinaryFormatter();
            T data;

            if (File.Exists(pathToSettings) == false)
            {
                data = (T)Activator.CreateInstance(typeof(T));
                using (FileStream stream = new FileStream(pathToSettings, FileMode.Create))
                {
                    formatter.Serialize(stream, data);
                }
            }
            else
            {
                using (FileStream stream = new FileStream(pathToSettings, FileMode.Open))
                {
                    data = (T)formatter.Deserialize(stream);
                }
            }
            return data;
        }

        private static void CheckDirectory()
        {
            if (Directory.Exists(Application.persistentDataPath + "/data") == false)
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/data");
            }
        }
    }
}