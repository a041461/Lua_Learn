print("*************Lua调用c#************")
--CS.命名空间.类名
--Unity类 CS.UnityEngine.类名
--CS.UnityEngine.GameObject

--通过c#中的类实例化对象 直接括号就是实例化
--默认调用无参构造
local obj1 = CS.UnityEngine.GameObject()
local obj2 = CS.UnityEngine.GameObject("Gobj")

--为了方便使用，节约性能，定义全局变量存储c#里的类
GameObject = CS.UnityEngine.GameObject
Debug = CS.UnityEngine.Debug
Vector3 = CS.UnityEngine.Vector3
local obj3 = GameObject("LuaGobj")

--类中静态对象可以直接使用.来使用
local obj4 =  GameObject.Find("Gobj")

--成员变量也可以直接.来使用
print(obj4.transform.position)
Debug.Log(obj4.transform.position)

--如果使用对象中的成员方法一定要加冒号调用
obj4.transform:Translate(Vector3.right)
Debug.Log(obj4.transform.position)

--自定义类 使用方法相同 命名空间不同
local t = CS.Test1()
t:Speak("test1说话")

local t2 = CS.LuaLearn.Test2()
t2:Speak("test2说话")

--继承Mono的类，不能直接new
local obj5 = GameObject("加脚本测试")
--Xlua提供typeof可以得到类的type
--Xlua中不支持无参泛型函数
obj5:AddComponent(typeof(CS.LuaCallCSharp))