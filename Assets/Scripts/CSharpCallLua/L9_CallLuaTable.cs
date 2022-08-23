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

        //不建议使用，效率低
        //引用拷贝，使用set更改
        LuaTable table =  LuaManager.GetInstance().Global.Get<LuaTable>("testClass");
        Debug.Log(table.Get<int>("testInt"));
        Debug.Log(table.Get<bool>("testBool"));

        table.Get<LuaFunction>("testFunction").Call();

        //记得销毁释放垃圾
        table.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
