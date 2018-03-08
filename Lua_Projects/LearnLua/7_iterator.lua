function values(t)
    local i = 0
    return function ()      -- closure 闭合函数
        i = i + 1
        return t[i]
    end
end

t1 = {10, 20, 30, 's', 50}

iter = values(t1)
while(true) do
    local element = iter();
    if element == nil then break end
    print(element);
end

print ("===========================================1")

for element in values(t1) do
    print(element)
end

print ("===========================================2")

-- function allwords()
--     local line = io.read()
--     local pos = 1
--     return function()
--         while line do
--             local s, e = string.find(line, "%w+", pos)
--             if s then 
--                 pos = e + 1
--                 return string.sub(line, s, e)
--             else
--                 line = io.read()
--                 pos = 1
--             end
--         end
--     end
-- end

-- for word in allwords() do
--     print(word)
-- end

print ("===========================================3")

function _ipairs(t)
    local i = 1
    return function ()
        local element = t[i]
        if element ~= nil then
           i = i + 1
           return element
        end
    end
end

t2 = {1, 2, 's', 4, 5}

for element in _ipairs(t2) do
    print(element)
end

print ("===========================================4")

t3 = {"x", "y", "z"}

local function iter (a, i)
    i = i + 1
    local v = a[i]
    if v then
        return i, v
    end
end

function __ipairs (a)
    return iter, a, 0
end

for i, v in __ipairs(t3) do
    print(i .. " " .. v)
end

-- 输出结果：
-- 1 x
-- 2 y
-- 3 z
