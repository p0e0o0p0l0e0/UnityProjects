Lib = {}

function Lib.foo (x, y) return x+y end
function Lib.goo (x, y) return x-y end

print(Lib.foo(10,20))
print(Lib.goo(10,20))