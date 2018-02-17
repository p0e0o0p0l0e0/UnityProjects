function derivative(f, delta)
	delta = delta or 1e-4
	return	function (x)
				return (f(x + delta) - f(x))/delta
			end
end

f = derivative(math.sin)

print ( math.cos(10) , f(10) )
