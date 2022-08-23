using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class LuaManager :Singleton<LuaManager>
{
    private LuaEnv luaEnv;

    public string LuaPath
    {
        get
        {
            return Application.dataPath + "/Lua/";
        }
    }
    /// <summary>
    /// 获取lua中的_G
    /// </summary>
    public LuaTable Global
    {
        get
        {
            return luaEnv.Global;
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        if(luaEnv != null)
        {
            return;
        }
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.AddLoader(MyCustomABLoader);
    }

    private byte[] MyCustomLoader(ref string filePath)
    {
        Debug.Log(filePath);
        string path = LuaPath + filePath + ".lua";
        Debug.Log(path);
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.LogError("重定向失败，文件名：" + path);
        }
        return null;
    }

    //重定向AB包
    private byte[] MyCustomABLoader(ref string filePath)
    {
        /*
        Debug.Log("从AB包中加载lua");
        //加载ab包
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/lua");

        TextAsset tx = ab.LoadAsset<TextAsset>(filePath+".lua");
        return tx.bytes;
        */
        TextAsset lua = ABManager.GetInstance().LoadRes<TextAsset>("lua", filePath + ".lua");
        if (lua != null)        
            return lua.bytes;
        
        else       
            Debug.LogError("AB包重定向失败，文件名：" + filePath);
        return null;
           

    }

    /// <summary>
    /// 执行Lua语句
    /// </summary>
    /// <param name="luastr"></param>
    public void DoString(string luastr)
    {
        luaEnv.DoString(luastr);
    }
    /// <summary>
    /// 执行lua脚本
    /// </summary>
    /// <param name="luafile"></param>
    public void DoLuaFile(string luafile)
    {
        string str = string.Format("require('{0}')", luafile);
        DoString(str);
    }

    /// <summary>
    /// 释放垃圾
    /// </summary>
    public void Tick()
    {
        luaEnv.Tick();
    }

    /// <summary>
    /// 销毁解析器
    /// </summary>
    public void Dispose()
    {
        luaEnv.Dispose();
        luaEnv = null;
    }


}
