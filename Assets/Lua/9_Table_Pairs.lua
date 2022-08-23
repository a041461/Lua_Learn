print("*******************迭代器遍历**********************")
a={[0]=0,1,2,3,[5] = 5}
for i, k in ipairs(a) do
    print("ipairs_"..i .. "_".. k)
end
for i in ipairs(a) do
    print("ipairs_key_"..i)
end

for i, k in pairs(a) do
    print("pairs_"..i .. "_".. k)
end
for i in pairs(a) do
    print("pairs_key_"..i)
end