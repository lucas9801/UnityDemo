---EmmyLua 调试配置 提交时一定要屏蔽
package.cpath = package.cpath .. ';C:/Users/admin/AppData/Roaming/JetBrains/Rider2022.1/plugins/EmmyLua/debugger/emmy/windows/x64/?.dll'
local dbg = require('emmy_core')
dbg.tcpConnect('localhost', 9966)

require("oop")
require("Core/Core")

LuaSetGlobalIfNil("g_mainLua",
{
    
})

LuaSetGlobalIfNil("g_xLuaUtils", require("HotFix/XLuaUtil"))
require('Core/ScriptTime')
require('Core/ScriptEvent')
require("HotFix/HotFix")


collectgarbage("setstepmul", 3000)

function g_mainLua:Update()
    if g_scriptEvent ~= nil then 
       g_scriptEvent:Update() 
    end
end

return g_mainLua