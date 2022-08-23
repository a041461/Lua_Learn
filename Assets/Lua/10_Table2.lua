print("**************字典***************")
a = {["name"] = "a",["age"]=14}
print(a["name"])
print(a.name)
print(a["age"])
a.name = "b"
print(a.name)
a.sex = false
print(a.sex)
a.sex = nil

print("**************遍历***************")
for key, value in pairs(a) do
    print(key,value)
end

print("**************类和结构体***************")
Student={
    age = 14,

    sex = true,

    Up = function ()
        print("UPUP")
    end,

    Study = function ()
        print("Study")
    end,    
    
    Learn = function (T)
        print(T.sex)
        print("Learn")
        
    end
    
}
Student.Up()
Student.Speak = function ()
    print("SpeakSpeak")
end
Student.Speak()
Student.Learn(Student)
Student:Learn()
function Student:Sleep()
    --self指代传入的第一个参数
    print(self.age.."Sleep")
end
Student:Sleep()

print("*****************表的公共操作*********************")
t1 = {{age = 1,name = "123"},{age = 2, name="321"}}
t2 = {name = "1234",sex = true}

--插入
print(#t1)
table.insert(t1,t2)
print(#t1)
print(t1[3].name)

--删除,删除最后一个索引
table.remove(t1)
print(#t1)
print(t1[1].name)
--移除对应索引
table.remove(t1,1)
--排序
t3={2,5,4,6,9,1}
table.sort(t3)
for key, value in pairs(t3) do
    print(value)
end
table.sort(t3,function (a, b)
    if a>b then
        return true
    end
end)
for key, value in pairs(t3) do
    print(value)
end

print("********拼接********************")
t4 = {"123","456",1}
str = table.concat(t4,";")
print(str)
