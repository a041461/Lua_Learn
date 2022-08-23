print("*************局部变量*************")
for i= 1,2 do
    local c = "123123"
end

fun = function ()
    local ff= "123123"
end
print("********多脚本执行*************")
require("test")
print(test1)
print(test2)

print("***********脚本卸载**********")
print(package.loaded["test"])
package.loaded["test"]=nil

print("***********大G表***********")
for key, value in pairs(_G) do
    print(key,value)
end
