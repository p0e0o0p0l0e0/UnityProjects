function room1 ()
    local direction = io.read()
    if direction == "east" then
        return room2()
    elseif direction == "south" then
        return room3()
    else
        print("invalid direction!")
        return room1()
    end
end

function room2 ()
    local direction = io.read()
    if direction == "west" then
        return room1()
    elseif direction == "south" then
        return room4()
    else
        print("invalid direction!")
        return room2()
    end
end

function room3 ()
    local direction = io.read()
    if direction == "north" then
        return room1()
    elseif direction == "east" then
        return room4()
    else
        print("invalid direction!")
        return room3()
    end

end

function room4 ()
    print("congratulations!")
end

room1()