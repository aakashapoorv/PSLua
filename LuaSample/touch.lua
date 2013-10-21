-- Variables

TitleString = "Lua Sample"
TitleStringX = 1

ColorList = {0xffff0000, 0xff00ff00,0xff0000ff,0xffffff00}
ColorIndex = 1

-- Functions

function OnTouch(pointX, pointY, isDown)
   -- print(string.format("%d %d %s", pointX, pointY, tostring(isDown)))
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
<<<<<<< HEAD
   -- print("0000000Ti")
=======
    print("Touch Event")
>>>>>>> 27ba49d2a274c352ed94cfdb8a630b52f57fad44
end

function OnPress (btnLua, isBtnDown)
--print(string.format("%s %s", btnLua, tostring(isBtnDown)))
btnText(tostring(btnLua))
<<<<<<< HEAD
if isBtnDown == true then
mytbl = fromCSV (btnLua)
=======
print("Button Event")
>>>>>>> 27ba49d2a274c352ed94cfdb8a630b52f57fad44

for i,line in ipairs(mytbl) do
	 line = line:gsub("%s+", "")
      print(line)
     
    end
end
end




function fromCSV (s)
  s = s .. ','        -- ending comma
  local t = {}        -- table to collect fields
  local fieldstart = 1
  repeat
    -- next field is quoted? (start with `"'?)
    if string.find(s, '^"', fieldstart) then
      local a, c
      local i  = fieldstart
      repeat
        -- find closing quote
        a, i, c = string.find(s, '"("?)', i+1)
      until c ~= '"'    -- quote not followed by quote?
      if not i then error('unmatched "') end
      local f = string.sub(s, fieldstart+1, i-1)
      table.insert(t, (string.gsub(f, '""', '"')))
      fieldstart = string.find(s, ',', i) + 1
    else                -- unquoted; find next comma
      local nexti = string.find(s, ',', fieldstart)
      table.insert(t, string.sub(s, fieldstart, nexti-1))
      fieldstart = nexti + 1
    end
  until fieldstart > string.len(s)
  return t
end


