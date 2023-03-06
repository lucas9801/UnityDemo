--HotFix Test
local hotfix = CS.HotFix()
local debug = CS.DebugL8

--注入前
hotfix:HotFixTest()

xlua.hotfix(CS.HotFix, "HotFixTest", function()
    debug.LogError("Lua HotFix")
end)

--注入后
hotfix:HotFixTest()


--协程替换
local wait = CS.UnityEngine.WaitForSeconds(1)

xlua.hotfix(CS.HotFix, {
    HotFixCor = function(self)
        return g_xLuaUtils.cs_generator(function()
            while(true) do
                coroutine.yield(wait)
                debug.LogError("Lua Coroutine")
            end
        end)
    end
})

local coroutine = CS.GlobalCoroutine.StartCoroutine(hotfix:HotFixCor())

local stopTable = {
    stopFunc = function()
        CS.GlobalCoroutine.StopCoroutine(coroutine)
    end
}

g_scriptEvent:DelayCall(5000, 0, 1, stopTable, "stopFunc")

