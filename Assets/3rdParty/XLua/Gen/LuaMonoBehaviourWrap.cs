#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class LuaMonoBehaviourWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaMonoBehaviour);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 2, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLuaTable", _m_GetLuaTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddButtonOnClick", _m_AddButtonOnClick);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddToggleOnValueChanged", _m_AddToggleOnValueChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddDropDownOnValueChanged", _m_AddDropDownOnValueChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddScrollRectOnValueChanged", _m_AddScrollRectOnValueChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSliderOnValueChanged", _m_AddSliderOnValueChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddInputFieldOnValueChange", _m_AddInputFieldOnValueChange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddInputFieldOnEndEdit", _m_AddInputFieldOnEndEdit);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_luaScript", _g_get_m_luaScript);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_ID", _g_get_m_ID);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_luaScript", _s_set_m_luaScript);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_ID", _s_set_m_ID);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "g_LuaTableID", _g_get_g_LuaTableID);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "g_LuaTableID", _s_set_g_LuaTableID);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new LuaMonoBehaviour();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LuaMonoBehaviour constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLuaTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetLuaTable(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddButtonOnClick(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.Button _button = (UnityEngine.UI.Button)translator.GetObject(L, 2, typeof(UnityEngine.UI.Button));
                    UnityEngine.Events.UnityAction<XLua.LuaTable, UnityEngine.GameObject> _call = translator.GetDelegate<UnityEngine.Events.UnityAction<XLua.LuaTable, UnityEngine.GameObject>>(L, 3);
                    
                    gen_to_be_invoked.AddButtonOnClick( _button, _call );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddToggleOnValueChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.Toggle _toggle = (UnityEngine.UI.Toggle)translator.GetObject(L, 2, typeof(UnityEngine.UI.Toggle));
                    UnityEngine.Events.UnityAction<XLua.LuaTable, bool, UnityEngine.UI.Toggle> _call = translator.GetDelegate<UnityEngine.Events.UnityAction<XLua.LuaTable, bool, UnityEngine.UI.Toggle>>(L, 3);
                    
                    gen_to_be_invoked.AddToggleOnValueChanged( _toggle, _call );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddDropDownOnValueChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.Dropdown _dropDown = (UnityEngine.UI.Dropdown)translator.GetObject(L, 2, typeof(UnityEngine.UI.Dropdown));
                    UnityEngine.Events.UnityAction<XLua.LuaTable, int> _call = translator.GetDelegate<UnityEngine.Events.UnityAction<XLua.LuaTable, int>>(L, 3);
                    
                    gen_to_be_invoked.AddDropDownOnValueChanged( _dropDown, _call );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddScrollRectOnValueChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.ScrollRect _scroll = (UnityEngine.UI.ScrollRect)translator.GetObject(L, 2, typeof(UnityEngine.UI.ScrollRect));
                    UnityEngine.Events.UnityAction<XLua.LuaTable, UnityEngine.Vector2> _call = translator.GetDelegate<UnityEngine.Events.UnityAction<XLua.LuaTable, UnityEngine.Vector2>>(L, 3);
                    
                    gen_to_be_invoked.AddScrollRectOnValueChanged( _scroll, _call );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSliderOnValueChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.Slider _slider = (UnityEngine.UI.Slider)translator.GetObject(L, 2, typeof(UnityEngine.UI.Slider));
                    UnityEngine.Events.UnityAction<XLua.LuaTable, float, UnityEngine.UI.Slider> _call = translator.GetDelegate<UnityEngine.Events.UnityAction<XLua.LuaTable, float, UnityEngine.UI.Slider>>(L, 3);
                    
                    gen_to_be_invoked.AddSliderOnValueChanged( _slider, _call );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddInputFieldOnValueChange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.InputField _inputField = (UnityEngine.UI.InputField)translator.GetObject(L, 2, typeof(UnityEngine.UI.InputField));
                    UnityEngine.Events.UnityAction<XLua.LuaTable, string> _call = translator.GetDelegate<UnityEngine.Events.UnityAction<XLua.LuaTable, string>>(L, 3);
                    
                    gen_to_be_invoked.AddInputFieldOnValueChange( _inputField, _call );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddInputFieldOnEndEdit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.UI.InputField _inputField = (UnityEngine.UI.InputField)translator.GetObject(L, 2, typeof(UnityEngine.UI.InputField));
                    UnityEngine.Events.UnityAction<XLua.LuaTable, string> _call = translator.GetDelegate<UnityEngine.Events.UnityAction<XLua.LuaTable, string>>(L, 3);
                    
                    gen_to_be_invoked.AddInputFieldOnEndEdit( _inputField, _call );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_g_LuaTableID(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushint64(L, LuaMonoBehaviour.g_LuaTableID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_luaScript(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.m_luaScript);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.m_ID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_g_LuaTableID(RealStatePtr L)
        {
		    try {
                
			    LuaMonoBehaviour.g_LuaTableID = LuaAPI.lua_toint64(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_luaScript(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_luaScript = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaMonoBehaviour gen_to_be_invoked = (LuaMonoBehaviour)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_ID = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
