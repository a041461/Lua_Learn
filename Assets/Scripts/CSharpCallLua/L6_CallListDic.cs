using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6_CallListDic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        List<int> list = LuaManager.GetInstance().Global.Get<List<int>>("testList");
        for(int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
        Debug.Log("****************************************");
        List<object> list2 = LuaManager.GetInstance().Global.Get<List<object>>("testList1");
        for (int i = 0; i < list2.Count; i++)
        {
            Debug.Log(list2[i]);
        }

        Dictionary<string,int> dic = LuaManager.GetInstance().Global.Get<Dictionary<string, int>>("testDic");
       foreach(string item in dic.Keys)
        {
            Debug.Log(item + "_" + dic[item]);
        }

        Dictionary<object, object> dic2 = LuaManager.GetInstance().Global.Get<Dictionary<object, object>>("testDic2");
        foreach (object item in dic2.Keys)
        {
            Debug.Log(item + "_" + dic2[item]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
