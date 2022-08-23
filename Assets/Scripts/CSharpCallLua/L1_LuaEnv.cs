using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class L1_LuaEnv : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaEnv env = new LuaEnv();

        env.DoString("print('Hello World')","L1_LuaEnv");
        //默认路径是Resources下 txt byte
        env.DoString("require('Main')");
        //主动垃圾回收
        //帧更新中定时执行
        env.Tick();
        //销毁lua解析器
        env.Dispose();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
