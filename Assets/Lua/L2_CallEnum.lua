print("*************Lua调用c#枚举************")

--枚举的调用规则和类的一致
PrimitiveType = CS.UnityEngine.PrimitiveType
GameObject = CS.UnityEngine.GameObject
Debug = CS.UnityEngine.Debug

local obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
--自定义枚举
E_MyEnm = CS.E_MyEnm

local c = E_MyEnm.Idle
print(c)
--枚举转换相关
--数值转枚举
local a = E_MyEnm.__CastFrom(1)
print(a)
--字符串转枚举
local b = E_MyEnm.__CastFrom("Attack")
print(b)