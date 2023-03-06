--lua端计时器
LuaSetGlobalIfNil("g_scriptEvent",
        {
            m_iDelayCallId = 0,
            m_tRtDelayCall = {},    --real time delay call
            m_lCurRealTime = 0,     --当前实时时间
            m_excuteCallIds = {},   --可执行的delayCall
            m_excuteCount = 0,
        });

function g_scriptEvent:DelayCall(fFirstDelayMS, fDelayMS, iLoopCount, tTable, strFunc, tParam)
    if type(fFirstDelayMS) ~= "number" or type(fDelayMS) ~= "number" or type(iLoopCount) ~= "number"
            or type(tTable) ~= "table" or type(strFunc) ~= "string" or strFunc == "" then
        CS.UnityEngine.Debug.LogError("DelayCall Error Arg")
        return 0
    end

    --TODO 此处应用服务器时间
    local currentTime = g_scriptTime:GetRealTimeSinceStartupMS()

    self.m_iDelayCallId = self.m_iDelayCallId + 1;
    local tCallItem =
    {
        callId = self.m_iDelayCallId,
        runCount = 0,
        nextRunTime = currentTime + fFirstDelayMS,
        fFirstDelayMS = fFirstDelayMS,
        fDelayMS = fDelayMS,
        iLoopCount = iLoopCount,
        tTable = tTable,
        strFunc = strFunc,
        tParam = tParam,
    }

    self.m_tRtDelayCall[self.m_iDelayCallId] = tCallItem
    return self.m_iDelayCallId
end

function g_scriptEvent:RemoveDelayCall(callId)
    if type(callId) ~= "number" or callId <= 0 then
        CS.UnityEngine.Debug.LogError("RemoveDelayCall Error arg")
    end
    self.m_tRtDelayCall[callId] = nil
end

function g_scriptEvent:ClearAll()
    self.m_tRtDelayCall = {}
end

function g_scriptEvent:Update()
    self:DispatchDelayCall()
end

function g_scriptEvent:DispatchDelayCall()
    self.m_lCurRealTime = g_scriptTime:GetRealTimeSinceStartupMS()

    self.m_excuteCallIds = {}
    --所有满足条件的延迟事件
    for k, tCallItem in pairs(self.m_tRtDelayCall) do
        if tCallItem.nextRunTime < self.m_lCurRealTime then
            table.insert(self.m_excuteCallIds, k)
        end
    end

    for i = 1, #self.m_excuteCallIds do
        local tCallItem = self.m_tRtDelayCall[self.m_excuteCallIds[i]]
        if tCallItem then
            --延迟调用一次
            if tCallItem.iLoopCount <= 0 then
                tCallItem.runCount = tCallItem.runCount + 1
                tCallItem.tTable[tCallItem.strFunc](tCallItem.tTable, tCallItem.tParam)
            else
                --循环结束
                if tCallItem.runCount > tCallItem.iLoopCount then
                    self.m_tRtDelayCall[tCallItem.callId] = nil
                else
                    tCallItem.runCount = tCallItem.runCount + 1
                    tCallItem.nextRunTime = self.m_lCurRealTime + tCallItem.fDelayMS
                    tCallItem.tTable[tCallItem.strFunc](tCallItem.tTable, tCallItem.tParam)
                end
            end
        end
    end
end 

return g_scriptEvent
