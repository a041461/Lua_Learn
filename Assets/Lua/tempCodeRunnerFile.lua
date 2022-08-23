print("*********面向对象***********")

print("*********封装***********")
Object = {}
Object.id = 1
function Object:Test()
    print(self.id)
end

function Object:new()
    local obj = {}
    self.__index = self
    setmetatable(obj,self)
    return obj
end

local myobj = Object:new()

print(myobj.id)
myobj.id = 2
myobj:Test()

print("*********继承***********")

function Object:subClass(className)
    _G[className] = {}
    local obj = _G[className]
    setmetatable(obj,self)
end

Object:subClass("Person")
print(Person.id)