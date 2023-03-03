namespace XLua.LuaDLL
{
    using System.Runtime.InteropServices;
    
    public partial class Lua
    {
        [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_memstream(System.IntPtr L);

        [MonoPInvokeCallback(typeof(lua_CSFunction))]
        public static int LoadMemStream(System.IntPtr L)
        {
            return luaopen_memstream(L);
        }

    }
}