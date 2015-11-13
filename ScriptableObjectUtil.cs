using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScriptableObjectUtil
{
    /// <summary>
    /// Creates a new ScriptableObject of a given type and saves it to an asset at the path
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T CreateAsset<T>(string path, string name) where T : ScriptableObject
    {
        T obj = ScriptableObject.CreateInstance<T>();
        AssetDatabase.CreateAsset(obj, Path.Combine(path, name + ".asset"));
        AssetDatabase.SaveAssets();
        return obj;
    }
}
