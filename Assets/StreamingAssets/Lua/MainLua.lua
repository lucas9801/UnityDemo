---EmmyLua 调试配置
package.cpath = package.cpath .. ';C:/Users/admin/AppData/Roaming/JetBrains/Rider2022.1/plugins/EmmyLua/debugger/emmy/windows/x64/?.dll'
local dbg = require('emmy_core')
dbg.tcpConnect('localhost', 9966)

require("oop")
require("Core/Core")

LuaSetGlobalIfNil("g_mainLua",
{
    
});

collectgarbage("setstepmul", 3000)

function g_mainLua:Update()
    
end

return g_mainLua