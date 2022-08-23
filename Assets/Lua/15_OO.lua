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
    self.__index = self
    obj.base=self;
    setmetatable(obj,self)
end

Object:subClass("Person")
local p1 = Person:new()
print(p1.id)
p1.id = 100
print(p1.id)

print("*********多态***********")
Object:subClass("GameObject")
GameObject.posX =0
GameObject.posY=0;
function  GameObject:Move()
    self.posX = self.posX +1
    self.posY = self.posY +1
    print(self.posX)
    print(self.posY)
end

GameObject:subClass("Player")

function Player:Move()
    --执行父类逻辑要通过.调用，自己传入第一个参数
    self.base.Move(self)
end

local p1 =Player:new()
p1:Move()

local p2 =Player:new()
p2:Move()

p2:Move()

