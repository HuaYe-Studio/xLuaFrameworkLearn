#if UNITY_EDITOR


using UnityEditor;
using UnityEngine;
using System.IO;

public class RenameLuaFiles
{
    [MenuItem("Tools/Rename Lua Files")]
    private static void RenameLuaFilesInProject()
    {
        string[] luaFiles = Directory.GetFiles(Application.dataPath, "*.lua", SearchOption.AllDirectories);

        foreach (string luaFile in luaFiles)
        {
            string newFileName = luaFile + ".txt";
            if (!File.Exists(newFileName))
            {
                File.Move(luaFile, newFileName);
                Debug.Log($"Renamed: {luaFile} to {newFileName}");
            }
            else
            {
                Debug.LogWarning($"File already exists: {newFileName}");
            }
        }

        AssetDatabase.Refresh();
    }
}
#endif