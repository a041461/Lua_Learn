using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4_Variable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        //LuaManager.GetInstance().DoString("require('Main')");
        LuaManager.GetInstance().DoLuaFile("Main");
        int testNumber = LuaManager.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + testNumber);
        bool testBool = LuaManager.GetInstance().Global.Get<bool>("testBool");
        Debug.Log("testBool:" + testBool);
        float testFloat = LuaManager.GetInstance().Global.Get<float>("testFloat");
        Debug.Log("testFloat:" + testFloat); 
        string testString = LuaManager.GetInstance().Global.Get<string>("testString");
        Debug.Log("testString:" + testString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
