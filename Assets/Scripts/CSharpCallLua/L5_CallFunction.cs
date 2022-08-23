using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;
//�޲��޷���
public delegate void CustomCall();
//�в��з���
//������ԣ�������
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
        //XLUA�Դ����÷��� ����
        LuaFunction lf = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun");
        lf.Call();

        //�в��з���
        CustomCall2 call2 = LuaManager.GetInstance().Global.Get<CustomCall2>("testFun2");
        Debug.Log("�в��з��أ�" + call2(10));
        //c#�ķ���ί��
        Func<int,int> sfunc = LuaManager.GetInstance().Global.Get<Func<int, int>>("testFun2");
        Debug.Log("�в��з��أ�" + sfunc(20));
        LuaFunction lf2 = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun2");     
        Debug.Log("�в��з��أ�" + lf2.Call(30)[0]);

        //�෵��ֵ
        CustomCall3 call3 = LuaManager.GetInstance().Global.Get<CustomCall3>("testFun3");
        int b;
        bool c;
        string d;
        Debug.Log("��һ������ֵ��" + call3(100, out b, out c, out d));
        Debug.Log(b + "_" + c + "_" + d);
        LuaFunction lf3 = LuaManager.GetInstance().Global.Get<LuaFunction>("testFun3");
        object[] objs = lf3.Call(100);
        for (int i = 0; i < objs.Length; i++)
            Debug.Log("����ֵΪ" + objs[i]);

        //�䳤����
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
