using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;
//无参无返回
public delegate void CustomCall();
//有参有返回
//添加特性，并生成
[CSharpCallLua]
public delegate int CustomCall2(int a);

[CSharpCallLua]
public delegate int CustomCall3(int a, out int b, out bool c,out string d);

[CSharpCallLua]
public delegate void CustomCall4(string a, params object[] args);

public class L5_CallFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();

        LuaManager.GetInstance().DoLuaFile("Main");

        CustomCall call = LuaManager.GetInstance().Global.Get<CustomCall>("testFun");
        call();
        UnityAction ua = LuaManager.GetInstance().Global.Get<UnityAction>("testFun");
        ua();
        Action ac = LuaManager.GetInstance().Global.Get<Action>("testFun");
        ac();
        //XLUA自带调用方法 少用
        LuaFunction lf = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun");
        lf.Call();

        //有参有返回
        CustomCall2 call2 = LuaManager.GetInstance().Global.Get<CustomCall2>("testFun2");
        Debug.Log("有参有返回：" + call2(10));
        //c#的泛型委托
        Func<int,int> sfunc = LuaManager.GetInstance().Global.Get<Func<int, int>>("testFun2");
        Debug.Log("有参有返回：" + sfunc(20));
        LuaFunction lf2 = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun2");     
        Debug.Log("有参有返回：" + lf2.Call(30)[0]);

        //多返回值
        CustomCall3 call3 = LuaManager.GetInstance().Global.Get<CustomCall3>("testFun3");
        int b;
        bool c;
        string d;
        Debug.Log("第一个返回值：" + call3(100, out b, out c, out d));
        Debug.Log(b + "_" + c + "_" + d);
        LuaFunction lf3 = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun3");
        object[] objs = lf3.Call(100);
        for (int i = 0; i < objs.Length; i++)
            Debug.Log("返回值为" + objs[i]);

        //变长参数
        CustomCall4 call4 = LuaManager.GetInstance().Global.Get<CustomCall4>("testFun4");
        call4("123",1,2,3,"6",true);
        LuaFunction lf4 = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun4");
        lf4.Call("321", 3, 2, 1, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
