using UnityEditor;
using UnityEngine;
using System.IO;

public class CreateLuaScript
{
    [MenuItem("Assets/Create/Lua Script", false, 10)]
    private static void CreateLuaScriptFile()
    {
        string path = GetSelectedPathOrFallback();
        string fileName = "NewLuaScript.lua";

        fileName = EditorUtility.SaveFilePanel("Save Lua Script", path, fileName, "lua");

        if (string.IsNullOrEmpty(fileName))
            return;

        if (File.Exists(fileName))
        {
            Debug.LogWarning("Lua script already exists at this location.");
            return;
        }

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("-- This is a new Lua script");
        }

        AssetDatabase.Refresh();
        Selection.activeObject = AssetDatabase.LoadAssetAtPath<Object>(fileName);
    }

    private static string GetSelectedPathOrFallback()
    {
        string path = "Assets";

        foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
}