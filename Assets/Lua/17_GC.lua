print("*****垃圾回收***********")
test = {id=1,name="asdasd"}
print(collectgarbage("count"))

collectgarbage("collect")
print(collectgarbage("count"))
--热更开发尽量不要自动GC