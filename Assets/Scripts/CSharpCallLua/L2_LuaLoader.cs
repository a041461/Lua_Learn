using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class L2_LuaLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaEnv env = new LuaEnv();
        env.AddLoader(MyCustomLoader);
        //��Ҫ��AB���м���lua
        env.DoString("require('Main')");
    }

    private byte[] MyCustomLoader(ref string filePath)
    {
        Debug.Log(filePath);
        string path = Application.dataPath + "/Lua/" + filePath + ".lua";
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
