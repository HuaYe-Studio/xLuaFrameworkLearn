using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Utility.SingletonPatternSystem;
using XLua;

public class XLuaManager : MonoSingleton<XLuaManager>
{
    private LuaEnv _luaEnv = null;

    protected override void Awake()
    {
        base.Awake();
        InitLuaEnv();
    }

    private void InitLuaEnv()
    {
        _luaEnv = new LuaEnv();
        _luaEnv.AddLoader(LuaScriptLoader);
    }

    public void EnterGame()
    {
        _luaEnv.DoString("print( 'Main')");
      
    }

    private byte[] LuaScriptLoader(ref string filepath)
    {   string scriptPath=String.Empty;
        filepath = filepath.Replace(".", "/")+ ".lua";
#if UNITY_EDITOR
        scriptPath=Path.Combine(Application.dataPath, "LuaScripts");
        scriptPath=Path.Combine(scriptPath, filepath);
        byte[] data=File.ReadAllBytes(scriptPath);
        return data;
#endif
        return null;
    }
}