LuaSetGlobalIfNil("g_scriptTime",
        {
            Time = CS.UnityEngine.Time,
            DaySecond = 86400,      --一天的秒数
            HourSecond = 3600,      --一个小时的秒数    
            MiniSecond = 60,        --一分钟的秒数
            SeverZone = -5,         --服务器所在时区
            isServerInSummerTime = true,    --服务器所在地区是否有夏令时
        });

function g_scriptTime:Update()
    self.hasGet = false
end

--TODO 获取服务器实时时间 毫秒
function g_scriptTime:GetServerRealTimeMS()

end

--TODO 获取服务器实时时间 秒
function g_scriptTime:GetServerRealTimeS()

end

--获取服务器 秒 带小数点
function g_scriptTime:GetServerRealTimeSWithDot()
    return self:GetServerRealTimeMS() / 1000
end

--获取当前游戏时间 秒
function g_scriptTime:GetRealTimeSinceStartup()
    return self:CSTime().realtimeSinceStartup
end

--获取当前游戏时间 毫秒
function g_scriptTime:GetRealTimeSinceStartupMS()
    return self:CSTime().realtimeSinceStartup * 1000
end

--保证每帧只跨语言获取实时deltaTime一次
function g_scriptTime:GetDeltaTime()
    if not self.hasGet then
        self.deltaTime = self:CSTime().deltaTime
        self.hasGet = true
    end
    return self.deltaTime
end

function g_scriptTime:CSTime()
    return self.Time
end

--获取服务器时间(时区), 格式方式和os.date一样
function g_scriptTime:ServerDateWithZone(format, serverTime)
    if serverTime == nil then
        serverTime = self:GetServerRealTimeS()
    end
    if serverTime <= 0 then
        serverTime = os.time(os.date("!*t"))
    end
    --格林尼治时间
    if format and not string.find(format, '!') then
        format = "!"..format
    end

    --有夏令时时 获取本地时间+1 获取服务器时间则-1
    serverTime = serverTime + g_scriptTime.SeverZone * g_scriptTime.HourSecond
    local tb = os.date(format, serverTime)
    local time = tb.isdst and os.date(format, serverTime - g_scriptTime.HourSecond) or tb
    return time
end

--获取当前时区
function g_scriptTime:getTimeZone()
    local now = os.time()
    local zone = math.floor(os.difftime(now, os.time(os.date("!*t", now))) / g_scriptTime.HourSecond)
    return zone
end

--获取服务器时间(时区) 相当于os.time
function g_scriptTime:GetTimestamp(timeTable)
    if timeTable.isdst then
        CS.UnityEngine.Debug.LogError("Have Summer Time")
    end
    local serverTime = os.time(timeTable)  - (g_scriptTime.SeverZone - g_scriptTime:getTimeZone()) * g_scriptTime.HourSecond

    --TODO
    --如果本地有夏令时 服务器没有夏令时
    --如果本地有夏令时 服务器也有夏令时
    --如果本地没有夏令时 服务器有夏令时
    --如果本地没有夏令时 服务器也没有夏令时

    return timeTable.isdst and serverTime - g_scriptTime.HourSecond or serverTime
end

return g_scriptTime

