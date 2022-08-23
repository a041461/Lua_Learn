function F1()
    print("F1")
end
F1()

F2 = function ()
    print("F2")
end
F2()

function F3(a)
    print(a)
end
F3(1)
F3("123")
F3(true)
F3()
F3(1,2,3)

function F4(a)
    return a,123,true
end
temp,temp1,temp2 = F4("123140")
print(temp)
print(temp1)
print(temp2)

function F5() 
end
print(type(F5))

function F6(...)
    arg = {...}
    for i = 1, #arg, 1 do
        print(arg[i])
    end
end
F6(1,2,"sada",true)

function F8()
    F9 = function ()
        print(123)      
    end
    return F9
end
F8()

--闭包
function F9(x)
    --改变传入参数的生命周期
    return function(y)
        return x+y
    end
end
F10 = F9(10)
print(F10(5))