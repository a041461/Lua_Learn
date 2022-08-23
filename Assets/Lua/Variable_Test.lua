print("Variable_Test")
testNumber = 1
testBool = true
testFloat = 1.2
testString = "123"

--c#无法获取lua局部变量
local testLocal = 10

testFun = function ()
    print("无参无返回")
end

testFun2 = function (a)
    print("有参有返回")
    return a+1
end

testFun3 = function (a)
    print("有参多返回")
    return 1,2,false,"a"
end

testFun4 = function (a,...)
    print("变长参数")
    print(a)
    arg = {...}
    for key, value in pairs(arg) do
        print(key,value)
    end
end

--List
testList = {1,2,3,4,5,6}
testList1 = {"123","abc",true,1,2}

--Dictionary
testDic = {
    ["1"] =1,
    ["2"] = 2,
    ["3"] = 3
}
testDic2 = {
    ["1"] = 1,
    [true] =1,
    ["dic"] = "Dictionary"
}
--类
testClass = {
    testInt = 2,
    testBool = true,
    testFloat = 1.2,
    testString ="123",
    testFun = function ()
        print("123123")
    end
}