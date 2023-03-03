---防止隐式声明全局变量

--设置全局变量 不允许value为nil
function LuaSetGlobal(xKey, xValue)
    if xKey == nil then
        error("LuaSetGlobal key is nil")
        return 
    end

    if type(xKey) ~= "string" then
        error("LuaSetGlobal xKey is not string type: " .. type(xKey))
        return
    end
    
    if xValue == nil then
        error("LuaSetGlobal XValue is nil")
        return 
    end
    
    rawset(_G, xKey, xValue)
end

--允许value为nil
function LuaSetGlobalAllowNilValue(xKey, xValue)
    if xKey == nil then
        error("LuaSetGlobal key is nil")
        return
    end

    if type(xKey) ~= "string" then
        error("LuaSetGlobal xKey is not string type:" ..type(xKey))
        return
    end

    rawset(_G, xKey, xValue)
end

--如果xKey对应的value不存在 则设置全局变量
function LuaSetGlobalIfNil(xKey, xValue)
    if xKey == nil then
        error("LuaSetGlobal key is nil")
        return
    end

    if type(xKey) ~= "string" then
        error("LuaSetGlobal xKey is not string type:" ..type(xKey))
        return
    end

    if xValue == nil then
        error("LuaSetGlobal value is nil")
        return
    end

    local oldValue = rawget(_G, xKey)
    if oldValue == nil then
        rawset(_G, xKey, xValue)
    end
end

--获取全局变量
function LuaGetGlobal(xKey)
    if xKey == nil then
        error("LuaSetGlobal key is nil")
        return
    end

    if type(xKey) ~= "string" then
        error("LuaSetGlobal xKey is not string type:" ..type(xKey))
        return
    end

    return rawget(_G, xKey)
end

--delete global
function LuaDelGlobal(xKey)
    if(xKey == nil) then error("LuaDelGlobal: key is nil"); return; end
    if(type(xKey) ~= "string") then error("LuaDelGlobal: key is not string, type: " .. type(xKey)); return; end

    rawset(_G, xKey, nil);
end

-- 表局表的创新 key 操作
local lMetaFuncNewIndex = function (tTable, xKey, xValue)
    error( string.format("Error set new global[k:%s], use LuaSetGlobal(k,v) or use local variable", tostring(xKey)) );
end

local lMetaFuncGetIndex = function (tTable, xKey)
    error( string.format("Error get nil global[k:%s], set first with LuaSetGlobal(k) or explicit use LuaGetGlobal(k)", tostring(xKey)) );
end

local lFuncInitGlobalHook = function()
    local lMetaTable = { __newindex = lMetaFuncNewIndex, __index = lMetaFuncGetIndex};
    setmetatable(_G, lMetaTable);
end

-- 创建全局变量 hook 函数，以免拼写错误声明了全局变量导致的很难发现的bug
lFuncInitGlobalHook();