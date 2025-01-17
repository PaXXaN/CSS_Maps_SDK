﻿using System.IO;
using UnityEngine;

public class OverViewSerialize : MonoBehaviour
{
    public class OverView
    {
        public string Texture;
        public float PosX;
        public float PosZ;
        public float Width;
        public float Height;
    }
    
#if UNITY_EDITOR
    public static void Save(string mapName, OverView overview)
    {
        string fullPath = $"{Path.GetFullPath(Path.Combine(Application.dataPath, "../"))}/maps/overviews/{mapName}";
        if (File.Exists(fullPath))
            File.Delete(fullPath);
        using (FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(JsonUtility.ToJson(overview, true));
            }
        }
    }
#endif
}
