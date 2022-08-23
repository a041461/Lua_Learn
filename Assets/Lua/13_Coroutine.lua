print("**************协程***********")

fun = function ()
    print("123")
end

co = coroutine.create(fun)
print(co)

co2 = coroutine.wrap(fun)
print(co2)

print("************协程运行*************")
coroutine.resume(co)
co2()

print("**************协程挂起****************")
fun2 = function ()
    local i = 1
    while true do
        print(i)
        i = i+1       
        print(coroutine.running())
        coroutine.yield()
    end
end
co3 = coroutine.create(fun2)
coroutine.resume(co3)
coroutine.resume(co3)
coroutine.resume(co3)

print(coroutine.status(co3))
print(coroutine.status(co))
print(coroutine.running())