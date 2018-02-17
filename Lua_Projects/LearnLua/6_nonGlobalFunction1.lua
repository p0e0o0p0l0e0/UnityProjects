-- local fact = function (n)
--     if n == 0 then return 1
--     else return n * fact(n-1) -- fact不存在，因为还没有定义结束，下面的两种方式都ok
--     end
-- end

-- local fact
-- fact = function (n)
--     if n == 0 then return 1
--     else return n * fact(n-1)
--     end
-- end

local function fact (n)
    if n == 0 then return 1
    else return n * fact(n-1)
    end
end

print (fact(4))