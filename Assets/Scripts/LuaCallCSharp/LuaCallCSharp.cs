using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 类与枚举
public class Test1
{
    public void Speak(string str)
    {
        Debug.Log("Test1_"+str);
    }
}
/// <summary>
/// 自定义测试枚举
/// </summary>
public enum E_MyEnm
{
    Idle,
    Move,
    Attack
}

namespace LuaLearn
{
    public class Test2
    {
        public void Speak(string str)
        {
            Debug.Log("Test2_" + str);
        }
    }
}
#endregion

#region 数组 List 字典
public class L3
{
    public int[] array = new int[] { 1, 2, 3, 4, 5 };

    public List<int> list = new List<int>();

    public Dictionary<int, string> dic = new Dictionary<int, string>();
}

#endregion
public class LuaCallCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
