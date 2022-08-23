str="双引号"
str1='单引号'

--英文占1个长度
s= "abcdefg"
print(#s)

--中文占3个长度
s = "1234567捌"
print(#s)

--转义
s="123\n123"
print(s)

--换行
s=[[
    123
    123
]]
print(s)

--字符串拼接 ..
s= "123"
s1= "321"
print(s .. s1)
print(string.format("%d",s))

--转字符串
print(tostring(s))

--字符串操作
--转大写
print(string.upper("aaaaaa"))
--转小写
print(string.lower("AAAAAAA"))
--逆序
print(string.reverse("1234567"))
--字符串索引查找,索引从1开始
print(string.find(s1,"2"))
--截取字符串
print(string.sub(s1,1,2))
print(string.sub(s1,2))
--字符串重复
print(string.rep(s1,2))
--字符串修改
print(string.gsub(s1,"1","**"))
--字符串转ASCII码
a = string.byte("Lua",1)
print(a)
print(string.char(a))