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
    /// ��ȡlua�е�_G
    /// </summary>
    public LuaTable Global
    {
        get
        {
            return luaEnv.Global;
        }
    }

    /// <summary>
    /// ��ʼ��
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
            Debug.LogError("�ض���ʧ�ܣ��ļ�����" + path);
        }
        return null;
    }

    //�ض���AB��
    private byte[] MyCustomABLoader(ref string filePath)
    {
        /*
        Debug.Log("��AB���м���lua");
        //����ab��
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/lua");

        TextAsset tx = ab.LoadAsset<TextAsset>(filePath+".lua");
        return tx.bytes;
        */
        TextAsset lua = ABManager.GetInstance().LoadRes<TextAsset>("lua", filePath + ".lua");
        if (lua != null)        
            return lua.bytes;
        
        else       
            Debug.LogError("AB���ض���ʧ�ܣ��ļ�����" + filePath);
        return null;
           

    }

    /// <summary>
    /// ִ��Lua���
    /// </summary>
    /// <param name="luastr"></param>
    public void DoString(string luastr)
    {
        luaEnv.DoString(luastr);
    }
    /// <summary>
    /// ִ��lua�ű�
    /// </summary>
    /// <param name="luafile"></param>
    public void DoLuaFile(string luafile)
    {
        string str = string.Format("require('{0}')", luafile);
        DoString(str);
    }

    /// <summary>
    /// �ͷ�����
    /// </summary>
    public void Tick()
    {
        luaEnv.Tick();
    }

    /// <summary>
    /// ���ٽ�����
    /// </summary>
    public void Dispose()
    {
        luaEnv.Dispose();
        luaEnv = null;
    }


}
