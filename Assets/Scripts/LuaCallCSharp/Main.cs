using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Lua无法直接访问c#，一定是先从c#调用Lua脚本后，才能访问c#
/// </summary>
public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
