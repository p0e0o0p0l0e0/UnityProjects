function values()
    local i = 0
    return function ()      -- closure 闭合函数
        i = i + 1
        return t[i]
    end
end

t = {10, 20, 30, 's', 50}

iter = values(t)
while(true) do
    local element = iter();
    if element == nil then break end
    print(element);
end
print ("===========================================")
for element in values(t) do
    print(element)
end
print ("===========================================")


function allwords()
    local line = io.read()
    local pos = 1
    return function()
        while line do
            local s, e = string.find(line, "%w+", pos)
            if s then 
                pos = e + 1
                return string.sub(line, s, e)
            else
                line = io.read()
                pos = 1
            end
        end
    end
end


for word in allwords() do
    print(word)
end

