using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

[CSharpCallLua]
//用属性来接受成员变量
public interface ICSharpCallInterface
{
    public int testInt
    {
        get;
        set;
    }

    bool testBool
    {
        get;
        set;
    }

    float testFloat
    {
        get;
        set;
    }

    string testString
    {
        get;
        set;
    }

    UnityAction testFun
    {
        get;
        set;
    }

}

public class L8_CallInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");
        ICSharpCallInterface obj = LuaManager.GetInstance().Global.Get<ICSharpCallInterface>("testClass");
        Debug.Log("接口");
        Debug.Log(obj.testInt);
        Debug.Log(obj.testBool);
        Debug.Log(obj.testFloat);
        Debug.Log(obj.testString);
        obj.testFun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
