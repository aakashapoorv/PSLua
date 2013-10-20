-- Variables

TitleString = "Lua Sample"
TitleStringX = 1

ColorList = {0xffff0000, 0xff00ff00,0xff0000ff,0xffffff00}
ColorIndex = 1

-- Functions

function OnTouch(pointX, pointY, isDown)
    print(string.format("%d %d %s", pointX, pointY, tostring(isDown)))
	TitleStringX = TitleStringX + 10
    if isDown then
        ColorIndex = ColorIndex + 1
    end
    if ColorIndex > #ColorList then
        ColorIndex = 1
    end
	TitleStringX = TitleStringX + 10
    -- Call C# function
    MoveText(TitleStringX)
    FillCircle(ColorList[ColorIndex], pointX, pointY, 120)
    print("0000000Ti")
end

function OnPress (btnLua, isBtnDown)
print(string.format("%s %s", btnLua, tostring(isBtnDown)))
btnText(tostring(btnLua))
print("Button Pressed")

end


