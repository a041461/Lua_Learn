print("*********元表*************")
meta = {}
mytable = {}

setmetatable(mytable,meta)

meta2={
    --当字表被当做字符串时，会调用元表的return
    __tostring=function (t)
        return t.name
    end,
    --当子表被当做函数使用时，会调用元表的__call
    __call = function (a,b)
        print(a)
        print(b)
        print("function.call")
    end,
    --加法运算符重载
    __add = function (t1,t2)
        return t1.age + t2.age
    end,
    --减法运算符
    __sub = function (t1,t2)
        return t1.age-t2.age
    end,
    --乘法
    __mul = function (t1,t2)
        return t1.age*t2.age
    end,
    --除法
    __div = function (t1,t2)
        return t1.age/t2.age
    end,
    --取余
    __mod = function (t1,t2)
        return t1.age%t2.age
    end,
    --次方
    __pow = function (t1,t2)
        return t1.age^t2.age
    end,
    -- ==
    __eq = function (t1,t2)
        return t1.age==t2.age
    end,
    -- <
    __lt = function (t1,t2)
        return t1.age<t2.age
    end,
    -- <=
    __le= function (t1,t2)
        return t1.age<=t2.age
    end,
    -- ..
    __concat = function (t1,t2)
        return t1.age..t2.age
    end,
    
}
mytable2 = {name = "321"}
setmetatable(mytable2,meta2)
print(mytable2)
mytable2(2)

print("*******特定操作************")
meta6 = {
    age = 1
}
meta6.__index = meta6
mytable6 ={}
setmetatable(mytable6,meta6)
--当子表中找不到属性时，会去__index指定的表里去找
print(mytable6.age)
--rawget 只找自身
print(rawget(mytable6,'age'))

print("**********_newindex******")
--新增赋值时，会去newindex的表里新增
meta7 = {}
meta7.__newindex = {}
mytable7={}
setmetatable(mytable7,meta7)
mytable7.age = 7
--rawset 只新增本身
rawset(mytable7,"age",7)
print(mytable7.age)
print(meta7.__newindex.age)