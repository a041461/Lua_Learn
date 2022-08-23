using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3_LuaMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        //LuaManager.GetInstance().DoString("require('Main')");
        LuaManager.GetInstance().DoLuaFile("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
