using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class L9_CallLuaTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");
        Debug.Log("LuaTable");

        //������ʹ�ã�Ч�ʵ�
        //���ÿ�����ʹ��set����
        LuaTable table =  LuaManager.GetInstance().Global.Get<LuaTable>("testClass");
        Debug.Log(table.Get<int>("testInt"));
        Debug.Log(table.Get<bool>("testBool"));

        table.Get<LuaFunction>("testFunction").Call();

        //�ǵ������ͷ�����
        table.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
