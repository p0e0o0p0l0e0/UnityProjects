t = {1, 3, nil, 4, 5}

function test(...)
	for i = 1, select('2', ...) do
		print(select(i, ...))
	end
end

test(unpack(t))

