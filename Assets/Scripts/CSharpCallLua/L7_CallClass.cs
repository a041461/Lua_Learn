using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallLuaClass
{
    //名字一定要和lua里一样
    public int testInt;
    public bool testBool;
    public float testFloat;
    public string testString;
    public UnityAction testFun;

}

public class L7_CallClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        CallLuaClass clc = LuaManager.GetInstance().Global.Get<CallLuaClass>("testClass");
        Debug.Log(clc.testInt);
        Debug.Log(clc.testBool); 
        Debug.Log(clc.testFloat); 
        Debug.Log(clc.testString);
        clc.testFun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
