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
    
    public class TutorialTestEnumWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Tutorial.TestEnum), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Tutorial.TestEnum), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Tutorial.TestEnum), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E1", Tutorial.TestEnum.E1);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E2", Tutorial.TestEnum.E2);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Tutorial.TestEnum), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushTutorialTestEnum(L, (Tutorial.TestEnum)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "E1"))
                {
                    translator.PushTutorialTestEnum(L, Tutorial.TestEnum.E1);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "E2"))
                {
                    translator.PushTutorialTestEnum(L, Tutorial.TestEnum.E2);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Tutorial.TestEnum!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Tutorial.TestEnum! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class XLuaTestMyEnumWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(XLuaTest.MyEnum), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(XLuaTest.MyEnum), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(XLuaTest.MyEnum), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E1", XLuaTest.MyEnum.E1);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E2", XLuaTest.MyEnum.E2);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(XLuaTest.MyEnum), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushXLuaTestMyEnum(L, (XLuaTest.MyEnum)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "E1"))
                {
                    translator.PushXLuaTestMyEnum(L, XLuaTest.MyEnum.E1);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "E2"))
                {
                    translator.PushXLuaTestMyEnum(L, XLuaTest.MyEnum.E2);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for XLuaTest.MyEnum!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for XLuaTest.MyEnum! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class TutorialDerivedClassTestEnumInnerWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E3", Tutorial.DerivedClass.TestEnumInner.E3);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "E4", Tutorial.DerivedClass.TestEnumInner.E4);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(Tutorial.DerivedClass.TestEnumInner), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushTutorialDerivedClassTestEnumInner(L, (Tutorial.DerivedClass.TestEnumInner)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "E3"))
                {
                    translator.PushTutorialDerivedClassTestEnumInner(L, Tutorial.DerivedClass.TestEnumInner.E3);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "E4"))
                {
                    translator.PushTutorialDerivedClassTestEnumInner(L, Tutorial.DerivedClass.TestEnumInner.E4);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for Tutorial.DerivedClass.TestEnumInner!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for Tutorial.DerivedClass.TestEnumInner! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCameraGateFitModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Camera.GateFitMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Camera.GateFitMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Camera.GateFitMode), L, null, 6, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", UnityEngine.Camera.GateFitMode.Vertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", UnityEngine.Camera.GateFitMode.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Fill", UnityEngine.Camera.GateFitMode.Fill);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Overscan", UnityEngine.Camera.GateFitMode.Overscan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.Camera.GateFitMode.None);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Camera.GateFitMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCameraGateFitMode(L, (UnityEngine.Camera.GateFitMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineCameraGateFitMode(L, UnityEngine.Camera.GateFitMode.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineCameraGateFitMode(L, UnityEngine.Camera.GateFitMode.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Fill"))
                {
                    translator.PushUnityEngineCameraGateFitMode(L, UnityEngine.Camera.GateFitMode.Fill);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Overscan"))
                {
                    translator.PushUnityEngineCameraGateFitMode(L, UnityEngine.Camera.GateFitMode.Overscan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineCameraGateFitMode(L, UnityEngine.Camera.GateFitMode.None);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Camera.GateFitMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Camera.GateFitMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCameraFieldOfViewAxisWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Camera.FieldOfViewAxis), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Camera.FieldOfViewAxis), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Camera.FieldOfViewAxis), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", UnityEngine.Camera.FieldOfViewAxis.Vertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", UnityEngine.Camera.FieldOfViewAxis.Horizontal);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Camera.FieldOfViewAxis), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCameraFieldOfViewAxis(L, (UnityEngine.Camera.FieldOfViewAxis)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineCameraFieldOfViewAxis(L, UnityEngine.Camera.FieldOfViewAxis.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineCameraFieldOfViewAxis(L, UnityEngine.Camera.FieldOfViewAxis.Horizontal);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Camera.FieldOfViewAxis!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Camera.FieldOfViewAxis! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCameraStereoscopicEyeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Camera.StereoscopicEye), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Camera.StereoscopicEye), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Camera.StereoscopicEye), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", UnityEngine.Camera.StereoscopicEye.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", UnityEngine.Camera.StereoscopicEye.Right);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Camera.StereoscopicEye), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCameraStereoscopicEye(L, (UnityEngine.Camera.StereoscopicEye)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineCameraStereoscopicEye(L, UnityEngine.Camera.StereoscopicEye.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineCameraStereoscopicEye(L, UnityEngine.Camera.StereoscopicEye.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Camera.StereoscopicEye!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Camera.StereoscopicEye! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCameraMonoOrStereoscopicEyeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Camera.MonoOrStereoscopicEye), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Camera.MonoOrStereoscopicEye), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Camera.MonoOrStereoscopicEye), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", UnityEngine.Camera.MonoOrStereoscopicEye.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", UnityEngine.Camera.MonoOrStereoscopicEye.Right);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Mono", UnityEngine.Camera.MonoOrStereoscopicEye.Mono);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Camera.MonoOrStereoscopicEye), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCameraMonoOrStereoscopicEye(L, (UnityEngine.Camera.MonoOrStereoscopicEye)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineCameraMonoOrStereoscopicEye(L, UnityEngine.Camera.MonoOrStereoscopicEye.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineCameraMonoOrStereoscopicEye(L, UnityEngine.Camera.MonoOrStereoscopicEye.Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Mono"))
                {
                    translator.PushUnityEngineCameraMonoOrStereoscopicEye(L, UnityEngine.Camera.MonoOrStereoscopicEye.Mono);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Camera.MonoOrStereoscopicEye!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Camera.MonoOrStereoscopicEye! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCameraSceneViewFilterModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Camera.SceneViewFilterMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Camera.SceneViewFilterMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Camera.SceneViewFilterMode), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Off", UnityEngine.Camera.SceneViewFilterMode.Off);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ShowFiltered", UnityEngine.Camera.SceneViewFilterMode.ShowFiltered);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Camera.SceneViewFilterMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCameraSceneViewFilterMode(L, (UnityEngine.Camera.SceneViewFilterMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Off"))
                {
                    translator.PushUnityEngineCameraSceneViewFilterMode(L, UnityEngine.Camera.SceneViewFilterMode.Off);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ShowFiltered"))
                {
                    translator.PushUnityEngineCameraSceneViewFilterMode(L, UnityEngine.Camera.SceneViewFilterMode.ShowFiltered);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Camera.SceneViewFilterMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Camera.SceneViewFilterMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCameraRenderRequestModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Camera.RenderRequestMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Camera.RenderRequestMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Camera.RenderRequestMode), L, null, 15, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.Camera.RenderRequestMode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ObjectId", UnityEngine.Camera.RenderRequestMode.ObjectId);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Depth", UnityEngine.Camera.RenderRequestMode.Depth);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "VertexNormal", UnityEngine.Camera.RenderRequestMode.VertexNormal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "WorldPosition", UnityEngine.Camera.RenderRequestMode.WorldPosition);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EntityId", UnityEngine.Camera.RenderRequestMode.EntityId);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BaseColor", UnityEngine.Camera.RenderRequestMode.BaseColor);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SpecularColor", UnityEngine.Camera.RenderRequestMode.SpecularColor);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Metallic", UnityEngine.Camera.RenderRequestMode.Metallic);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Emission", UnityEngine.Camera.RenderRequestMode.Emission);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Normal", UnityEngine.Camera.RenderRequestMode.Normal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Smoothness", UnityEngine.Camera.RenderRequestMode.Smoothness);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Occlusion", UnityEngine.Camera.RenderRequestMode.Occlusion);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DiffuseColor", UnityEngine.Camera.RenderRequestMode.DiffuseColor);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Camera.RenderRequestMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCameraRenderRequestMode(L, (UnityEngine.Camera.RenderRequestMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ObjectId"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.ObjectId);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Depth"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.Depth);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "VertexNormal"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.VertexNormal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WorldPosition"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.WorldPosition);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EntityId"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.EntityId);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BaseColor"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.BaseColor);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SpecularColor"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.SpecularColor);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Metallic"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.Metallic);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Emission"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.Emission);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Smoothness"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.Smoothness);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Occlusion"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.Occlusion);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DiffuseColor"))
                {
                    translator.PushUnityEngineCameraRenderRequestMode(L, UnityEngine.Camera.RenderRequestMode.DiffuseColor);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Camera.RenderRequestMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Camera.RenderRequestMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCameraRenderRequestOutputSpaceWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Camera.RenderRequestOutputSpace), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Camera.RenderRequestOutputSpace), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Camera.RenderRequestOutputSpace), L, null, 11, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScreenSpace", UnityEngine.Camera.RenderRequestOutputSpace.ScreenSpace);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV0", UnityEngine.Camera.RenderRequestOutputSpace.UV0);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV1", UnityEngine.Camera.RenderRequestOutputSpace.UV1);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV2", UnityEngine.Camera.RenderRequestOutputSpace.UV2);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV3", UnityEngine.Camera.RenderRequestOutputSpace.UV3);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV4", UnityEngine.Camera.RenderRequestOutputSpace.UV4);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV5", UnityEngine.Camera.RenderRequestOutputSpace.UV5);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV6", UnityEngine.Camera.RenderRequestOutputSpace.UV6);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV7", UnityEngine.Camera.RenderRequestOutputSpace.UV7);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UV8", UnityEngine.Camera.RenderRequestOutputSpace.UV8);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Camera.RenderRequestOutputSpace), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCameraRenderRequestOutputSpace(L, (UnityEngine.Camera.RenderRequestOutputSpace)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "ScreenSpace"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.ScreenSpace);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV0"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV0);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV1"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV1);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV2"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV3"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV3);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV4"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV4);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV5"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV5);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV6"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV6);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV7"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV7);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UV8"))
                {
                    translator.PushUnityEngineCameraRenderRequestOutputSpace(L, UnityEngine.Camera.RenderRequestOutputSpace.UV8);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Camera.RenderRequestOutputSpace!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Camera.RenderRequestOutputSpace! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineReflectionProbeReflectionProbeEventWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.ReflectionProbe.ReflectionProbeEvent), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.ReflectionProbe.ReflectionProbeEvent), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.ReflectionProbe.ReflectionProbeEvent), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ReflectionProbeAdded", UnityEngine.ReflectionProbe.ReflectionProbeEvent.ReflectionProbeAdded);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ReflectionProbeRemoved", UnityEngine.ReflectionProbe.ReflectionProbeEvent.ReflectionProbeRemoved);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.ReflectionProbe.ReflectionProbeEvent), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineReflectionProbeReflectionProbeEvent(L, (UnityEngine.ReflectionProbe.ReflectionProbeEvent)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "ReflectionProbeAdded"))
                {
                    translator.PushUnityEngineReflectionProbeReflectionProbeEvent(L, UnityEngine.ReflectionProbe.ReflectionProbeEvent.ReflectionProbeAdded);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ReflectionProbeRemoved"))
                {
                    translator.PushUnityEngineReflectionProbeReflectionProbeEvent(L, UnityEngine.ReflectionProbe.ReflectionProbeEvent.ReflectionProbeRemoved);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.ReflectionProbe.ReflectionProbeEvent!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.ReflectionProbe.ReflectionProbeEvent! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightingSettingsLightmapperWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightingSettings.Lightmapper), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightingSettings.Lightmapper), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightingSettings.Lightmapper), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Enlighten", UnityEngine.LightingSettings.Lightmapper.Enlighten);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ProgressiveCPU", UnityEngine.LightingSettings.Lightmapper.ProgressiveCPU);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ProgressiveGPU", UnityEngine.LightingSettings.Lightmapper.ProgressiveGPU);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightingSettings.Lightmapper), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightingSettingsLightmapper(L, (UnityEngine.LightingSettings.Lightmapper)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Enlighten"))
                {
                    translator.PushUnityEngineLightingSettingsLightmapper(L, UnityEngine.LightingSettings.Lightmapper.Enlighten);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ProgressiveCPU"))
                {
                    translator.PushUnityEngineLightingSettingsLightmapper(L, UnityEngine.LightingSettings.Lightmapper.ProgressiveCPU);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ProgressiveGPU"))
                {
                    translator.PushUnityEngineLightingSettingsLightmapper(L, UnityEngine.LightingSettings.Lightmapper.ProgressiveGPU);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightingSettings.Lightmapper!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightingSettings.Lightmapper! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightingSettingsSamplingWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightingSettings.Sampling), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightingSettings.Sampling), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightingSettings.Sampling), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Auto", UnityEngine.LightingSettings.Sampling.Auto);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Fixed", UnityEngine.LightingSettings.Sampling.Fixed);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightingSettings.Sampling), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightingSettingsSampling(L, (UnityEngine.LightingSettings.Sampling)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Auto"))
                {
                    translator.PushUnityEngineLightingSettingsSampling(L, UnityEngine.LightingSettings.Sampling.Auto);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Fixed"))
                {
                    translator.PushUnityEngineLightingSettingsSampling(L, UnityEngine.LightingSettings.Sampling.Fixed);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightingSettings.Sampling!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightingSettings.Sampling! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightingSettingsFilterModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightingSettings.FilterMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightingSettings.FilterMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightingSettings.FilterMode), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.LightingSettings.FilterMode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Auto", UnityEngine.LightingSettings.FilterMode.Auto);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Advanced", UnityEngine.LightingSettings.FilterMode.Advanced);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightingSettings.FilterMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightingSettingsFilterMode(L, (UnityEngine.LightingSettings.FilterMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineLightingSettingsFilterMode(L, UnityEngine.LightingSettings.FilterMode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Auto"))
                {
                    translator.PushUnityEngineLightingSettingsFilterMode(L, UnityEngine.LightingSettings.FilterMode.Auto);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Advanced"))
                {
                    translator.PushUnityEngineLightingSettingsFilterMode(L, UnityEngine.LightingSettings.FilterMode.Advanced);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightingSettings.FilterMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightingSettings.FilterMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightingSettingsDenoiserTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightingSettings.DenoiserType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightingSettings.DenoiserType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightingSettings.DenoiserType), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.LightingSettings.DenoiserType.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Optix", UnityEngine.LightingSettings.DenoiserType.Optix);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OpenImage", UnityEngine.LightingSettings.DenoiserType.OpenImage);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RadeonPro", UnityEngine.LightingSettings.DenoiserType.RadeonPro);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightingSettings.DenoiserType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightingSettingsDenoiserType(L, (UnityEngine.LightingSettings.DenoiserType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineLightingSettingsDenoiserType(L, UnityEngine.LightingSettings.DenoiserType.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Optix"))
                {
                    translator.PushUnityEngineLightingSettingsDenoiserType(L, UnityEngine.LightingSettings.DenoiserType.Optix);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OpenImage"))
                {
                    translator.PushUnityEngineLightingSettingsDenoiserType(L, UnityEngine.LightingSettings.DenoiserType.OpenImage);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RadeonPro"))
                {
                    translator.PushUnityEngineLightingSettingsDenoiserType(L, UnityEngine.LightingSettings.DenoiserType.RadeonPro);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightingSettings.DenoiserType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightingSettings.DenoiserType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightingSettingsFilterTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightingSettings.FilterType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightingSettings.FilterType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightingSettings.FilterType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Gaussian", UnityEngine.LightingSettings.FilterType.Gaussian);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ATrous", UnityEngine.LightingSettings.FilterType.ATrous);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.LightingSettings.FilterType.None);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightingSettings.FilterType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightingSettingsFilterType(L, (UnityEngine.LightingSettings.FilterType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Gaussian"))
                {
                    translator.PushUnityEngineLightingSettingsFilterType(L, UnityEngine.LightingSettings.FilterType.Gaussian);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ATrous"))
                {
                    translator.PushUnityEngineLightingSettingsFilterType(L, UnityEngine.LightingSettings.FilterType.ATrous);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineLightingSettingsFilterType(L, UnityEngine.LightingSettings.FilterType.None);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightingSettings.FilterType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightingSettings.FilterType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineGraphicsBufferTargetWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.GraphicsBuffer.Target), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.GraphicsBuffer.Target), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.GraphicsBuffer.Target), L, null, 11, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertex", UnityEngine.GraphicsBuffer.Target.Vertex);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Index", UnityEngine.GraphicsBuffer.Target.Index);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CopySource", UnityEngine.GraphicsBuffer.Target.CopySource);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CopyDestination", UnityEngine.GraphicsBuffer.Target.CopyDestination);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Structured", UnityEngine.GraphicsBuffer.Target.Structured);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Raw", UnityEngine.GraphicsBuffer.Target.Raw);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Append", UnityEngine.GraphicsBuffer.Target.Append);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Counter", UnityEngine.GraphicsBuffer.Target.Counter);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IndirectArguments", UnityEngine.GraphicsBuffer.Target.IndirectArguments);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Constant", UnityEngine.GraphicsBuffer.Target.Constant);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.GraphicsBuffer.Target), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineGraphicsBufferTarget(L, (UnityEngine.GraphicsBuffer.Target)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Vertex"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.Vertex);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Index"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.Index);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CopySource"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.CopySource);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CopyDestination"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.CopyDestination);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Structured"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.Structured);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Raw"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.Raw);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Append"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.Append);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Counter"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.Counter);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IndirectArguments"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.IndirectArguments);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Constant"))
                {
                    translator.PushUnityEngineGraphicsBufferTarget(L, UnityEngine.GraphicsBuffer.Target.Constant);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.GraphicsBuffer.Target!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.GraphicsBuffer.Target! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightProbeProxyVolumeResolutionModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.ResolutionMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.ResolutionMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightProbeProxyVolume.ResolutionMode), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Automatic", UnityEngine.LightProbeProxyVolume.ResolutionMode.Automatic);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom", UnityEngine.LightProbeProxyVolume.ResolutionMode.Custom);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightProbeProxyVolume.ResolutionMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightProbeProxyVolumeResolutionMode(L, (UnityEngine.LightProbeProxyVolume.ResolutionMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Automatic"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeResolutionMode(L, UnityEngine.LightProbeProxyVolume.ResolutionMode.Automatic);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeResolutionMode(L, UnityEngine.LightProbeProxyVolume.ResolutionMode.Custom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightProbeProxyVolume.ResolutionMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightProbeProxyVolume.ResolutionMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightProbeProxyVolumeBoundingBoxModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.BoundingBoxMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.BoundingBoxMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightProbeProxyVolume.BoundingBoxMode), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutomaticLocal", UnityEngine.LightProbeProxyVolume.BoundingBoxMode.AutomaticLocal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutomaticWorld", UnityEngine.LightProbeProxyVolume.BoundingBoxMode.AutomaticWorld);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom", UnityEngine.LightProbeProxyVolume.BoundingBoxMode.Custom);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightProbeProxyVolume.BoundingBoxMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightProbeProxyVolumeBoundingBoxMode(L, (UnityEngine.LightProbeProxyVolume.BoundingBoxMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "AutomaticLocal"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeBoundingBoxMode(L, UnityEngine.LightProbeProxyVolume.BoundingBoxMode.AutomaticLocal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutomaticWorld"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeBoundingBoxMode(L, UnityEngine.LightProbeProxyVolume.BoundingBoxMode.AutomaticWorld);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeBoundingBoxMode(L, UnityEngine.LightProbeProxyVolume.BoundingBoxMode.Custom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightProbeProxyVolume.BoundingBoxMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightProbeProxyVolume.BoundingBoxMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightProbeProxyVolumeProbePositionModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.ProbePositionMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.ProbePositionMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightProbeProxyVolume.ProbePositionMode), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CellCorner", UnityEngine.LightProbeProxyVolume.ProbePositionMode.CellCorner);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CellCenter", UnityEngine.LightProbeProxyVolume.ProbePositionMode.CellCenter);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightProbeProxyVolume.ProbePositionMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightProbeProxyVolumeProbePositionMode(L, (UnityEngine.LightProbeProxyVolume.ProbePositionMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "CellCorner"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeProbePositionMode(L, UnityEngine.LightProbeProxyVolume.ProbePositionMode.CellCorner);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CellCenter"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeProbePositionMode(L, UnityEngine.LightProbeProxyVolume.ProbePositionMode.CellCenter);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightProbeProxyVolume.ProbePositionMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightProbeProxyVolume.ProbePositionMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightProbeProxyVolumeRefreshModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.RefreshMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.RefreshMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightProbeProxyVolume.RefreshMode), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Automatic", UnityEngine.LightProbeProxyVolume.RefreshMode.Automatic);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EveryFrame", UnityEngine.LightProbeProxyVolume.RefreshMode.EveryFrame);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ViaScripting", UnityEngine.LightProbeProxyVolume.RefreshMode.ViaScripting);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightProbeProxyVolume.RefreshMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightProbeProxyVolumeRefreshMode(L, (UnityEngine.LightProbeProxyVolume.RefreshMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Automatic"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeRefreshMode(L, UnityEngine.LightProbeProxyVolume.RefreshMode.Automatic);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EveryFrame"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeRefreshMode(L, UnityEngine.LightProbeProxyVolume.RefreshMode.EveryFrame);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ViaScripting"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeRefreshMode(L, UnityEngine.LightProbeProxyVolume.RefreshMode.ViaScripting);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightProbeProxyVolume.RefreshMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightProbeProxyVolume.RefreshMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightProbeProxyVolumeQualityModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.QualityMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.QualityMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightProbeProxyVolume.QualityMode), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Low", UnityEngine.LightProbeProxyVolume.QualityMode.Low);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Normal", UnityEngine.LightProbeProxyVolume.QualityMode.Normal);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightProbeProxyVolume.QualityMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightProbeProxyVolumeQualityMode(L, (UnityEngine.LightProbeProxyVolume.QualityMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Low"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeQualityMode(L, UnityEngine.LightProbeProxyVolume.QualityMode.Low);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeQualityMode(L, UnityEngine.LightProbeProxyVolume.QualityMode.Normal);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightProbeProxyVolume.QualityMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightProbeProxyVolume.QualityMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineLightProbeProxyVolumeDataFormatWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.DataFormat), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.LightProbeProxyVolume.DataFormat), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.LightProbeProxyVolume.DataFormat), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HalfFloat", UnityEngine.LightProbeProxyVolume.DataFormat.HalfFloat);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Float", UnityEngine.LightProbeProxyVolume.DataFormat.Float);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.LightProbeProxyVolume.DataFormat), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineLightProbeProxyVolumeDataFormat(L, (UnityEngine.LightProbeProxyVolume.DataFormat)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "HalfFloat"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeDataFormat(L, UnityEngine.LightProbeProxyVolume.DataFormat.HalfFloat);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Float"))
                {
                    translator.PushUnityEngineLightProbeProxyVolumeDataFormat(L, UnityEngine.LightProbeProxyVolume.DataFormat.Float);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.LightProbeProxyVolume.DataFormat!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.LightProbeProxyVolume.DataFormat! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineTexture2DEXRFlagsWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, null, 6, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.Texture2D.EXRFlags.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "OutputAsFloat", UnityEngine.Texture2D.EXRFlags.OutputAsFloat);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CompressZIP", UnityEngine.Texture2D.EXRFlags.CompressZIP);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CompressRLE", UnityEngine.Texture2D.EXRFlags.CompressRLE);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CompressPIZ", UnityEngine.Texture2D.EXRFlags.CompressPIZ);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.Texture2D.EXRFlags), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineTexture2DEXRFlags(L, (UnityEngine.Texture2D.EXRFlags)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "OutputAsFloat"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.OutputAsFloat);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CompressZIP"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.CompressZIP);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CompressRLE"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.CompressRLE);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CompressPIZ"))
                {
                    translator.PushUnityEngineTexture2DEXRFlags(L, UnityEngine.Texture2D.EXRFlags.CompressPIZ);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.Texture2D.EXRFlags!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.Texture2D.EXRFlags! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineRectTransformEdgeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.RectTransform.Edge), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.RectTransform.Edge), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.RectTransform.Edge), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", UnityEngine.RectTransform.Edge.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", UnityEngine.RectTransform.Edge.Right);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", UnityEngine.RectTransform.Edge.Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", UnityEngine.RectTransform.Edge.Bottom);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.RectTransform.Edge), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineRectTransformEdge(L, (UnityEngine.RectTransform.Edge)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineRectTransformEdge(L, UnityEngine.RectTransform.Edge.Bottom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.RectTransform.Edge!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.RectTransform.Edge! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineRectTransformAxisWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.RectTransform.Axis), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.RectTransform.Axis), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.RectTransform.Axis), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", UnityEngine.RectTransform.Axis.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", UnityEngine.RectTransform.Axis.Vertical);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.RectTransform.Axis), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineRectTransformAxis(L, (UnityEngine.RectTransform.Axis)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineRectTransformAxis(L, UnityEngine.RectTransform.Axis.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineRectTransformAxis(L, UnityEngine.RectTransform.Axis.Vertical);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.RectTransform.Axis!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.RectTransform.Axis! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineGridLayoutCellLayoutWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.GridLayout.CellLayout), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.GridLayout.CellLayout), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.GridLayout.CellLayout), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Rectangle", UnityEngine.GridLayout.CellLayout.Rectangle);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Hexagon", UnityEngine.GridLayout.CellLayout.Hexagon);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Isometric", UnityEngine.GridLayout.CellLayout.Isometric);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IsometricZAsY", UnityEngine.GridLayout.CellLayout.IsometricZAsY);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.GridLayout.CellLayout), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineGridLayoutCellLayout(L, (UnityEngine.GridLayout.CellLayout)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Rectangle"))
                {
                    translator.PushUnityEngineGridLayoutCellLayout(L, UnityEngine.GridLayout.CellLayout.Rectangle);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Hexagon"))
                {
                    translator.PushUnityEngineGridLayoutCellLayout(L, UnityEngine.GridLayout.CellLayout.Hexagon);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Isometric"))
                {
                    translator.PushUnityEngineGridLayoutCellLayout(L, UnityEngine.GridLayout.CellLayout.Isometric);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IsometricZAsY"))
                {
                    translator.PushUnityEngineGridLayoutCellLayout(L, UnityEngine.GridLayout.CellLayout.IsometricZAsY);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.GridLayout.CellLayout!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.GridLayout.CellLayout! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineGridLayoutCellSwizzleWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.GridLayout.CellSwizzle), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.GridLayout.CellSwizzle), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.GridLayout.CellSwizzle), L, null, 7, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "XYZ", UnityEngine.GridLayout.CellSwizzle.XYZ);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "XZY", UnityEngine.GridLayout.CellSwizzle.XZY);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "YXZ", UnityEngine.GridLayout.CellSwizzle.YXZ);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "YZX", UnityEngine.GridLayout.CellSwizzle.YZX);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ZXY", UnityEngine.GridLayout.CellSwizzle.ZXY);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ZYX", UnityEngine.GridLayout.CellSwizzle.ZYX);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.GridLayout.CellSwizzle), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineGridLayoutCellSwizzle(L, (UnityEngine.GridLayout.CellSwizzle)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "XYZ"))
                {
                    translator.PushUnityEngineGridLayoutCellSwizzle(L, UnityEngine.GridLayout.CellSwizzle.XYZ);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "XZY"))
                {
                    translator.PushUnityEngineGridLayoutCellSwizzle(L, UnityEngine.GridLayout.CellSwizzle.XZY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "YXZ"))
                {
                    translator.PushUnityEngineGridLayoutCellSwizzle(L, UnityEngine.GridLayout.CellSwizzle.YXZ);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "YZX"))
                {
                    translator.PushUnityEngineGridLayoutCellSwizzle(L, UnityEngine.GridLayout.CellSwizzle.YZX);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ZXY"))
                {
                    translator.PushUnityEngineGridLayoutCellSwizzle(L, UnityEngine.GridLayout.CellSwizzle.ZXY);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ZYX"))
                {
                    translator.PushUnityEngineGridLayoutCellSwizzle(L, UnityEngine.GridLayout.CellSwizzle.ZYX);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.GridLayout.CellSwizzle!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.GridLayout.CellSwizzle! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCompositeCollider2DGeometryTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.CompositeCollider2D.GeometryType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.CompositeCollider2D.GeometryType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.CompositeCollider2D.GeometryType), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Outlines", UnityEngine.CompositeCollider2D.GeometryType.Outlines);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Polygons", UnityEngine.CompositeCollider2D.GeometryType.Polygons);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.CompositeCollider2D.GeometryType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCompositeCollider2DGeometryType(L, (UnityEngine.CompositeCollider2D.GeometryType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Outlines"))
                {
                    translator.PushUnityEngineCompositeCollider2DGeometryType(L, UnityEngine.CompositeCollider2D.GeometryType.Outlines);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Polygons"))
                {
                    translator.PushUnityEngineCompositeCollider2DGeometryType(L, UnityEngine.CompositeCollider2D.GeometryType.Polygons);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.CompositeCollider2D.GeometryType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.CompositeCollider2D.GeometryType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineCompositeCollider2DGenerationTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.CompositeCollider2D.GenerationType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.CompositeCollider2D.GenerationType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.CompositeCollider2D.GenerationType), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Synchronous", UnityEngine.CompositeCollider2D.GenerationType.Synchronous);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Manual", UnityEngine.CompositeCollider2D.GenerationType.Manual);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.CompositeCollider2D.GenerationType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineCompositeCollider2DGenerationType(L, (UnityEngine.CompositeCollider2D.GenerationType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Synchronous"))
                {
                    translator.PushUnityEngineCompositeCollider2DGenerationType(L, UnityEngine.CompositeCollider2D.GenerationType.Synchronous);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Manual"))
                {
                    translator.PushUnityEngineCompositeCollider2DGenerationType(L, UnityEngine.CompositeCollider2D.GenerationType.Manual);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.CompositeCollider2D.GenerationType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.CompositeCollider2D.GenerationType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineScreenCaptureStereoScreenCaptureModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.ScreenCapture.StereoScreenCaptureMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.ScreenCapture.StereoScreenCaptureMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.ScreenCapture.StereoScreenCaptureMode), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LeftEye", UnityEngine.ScreenCapture.StereoScreenCaptureMode.LeftEye);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RightEye", UnityEngine.ScreenCapture.StereoScreenCaptureMode.RightEye);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BothEyes", UnityEngine.ScreenCapture.StereoScreenCaptureMode.BothEyes);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.ScreenCapture.StereoScreenCaptureMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineScreenCaptureStereoScreenCaptureMode(L, (UnityEngine.ScreenCapture.StereoScreenCaptureMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "LeftEye"))
                {
                    translator.PushUnityEngineScreenCaptureStereoScreenCaptureMode(L, UnityEngine.ScreenCapture.StereoScreenCaptureMode.LeftEye);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RightEye"))
                {
                    translator.PushUnityEngineScreenCaptureStereoScreenCaptureMode(L, UnityEngine.ScreenCapture.StereoScreenCaptureMode.RightEye);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BothEyes"))
                {
                    translator.PushUnityEngineScreenCaptureStereoScreenCaptureMode(L, UnityEngine.ScreenCapture.StereoScreenCaptureMode.BothEyes);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.ScreenCapture.StereoScreenCaptureMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.ScreenCapture.StereoScreenCaptureMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineGridBrushBaseToolWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.GridBrushBase.Tool), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.GridBrushBase.Tool), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.GridBrushBase.Tool), L, null, 8, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Select", UnityEngine.GridBrushBase.Tool.Select);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Move", UnityEngine.GridBrushBase.Tool.Move);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Paint", UnityEngine.GridBrushBase.Tool.Paint);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Box", UnityEngine.GridBrushBase.Tool.Box);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Pick", UnityEngine.GridBrushBase.Tool.Pick);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Erase", UnityEngine.GridBrushBase.Tool.Erase);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FloodFill", UnityEngine.GridBrushBase.Tool.FloodFill);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.GridBrushBase.Tool), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineGridBrushBaseTool(L, (UnityEngine.GridBrushBase.Tool)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Select"))
                {
                    translator.PushUnityEngineGridBrushBaseTool(L, UnityEngine.GridBrushBase.Tool.Select);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Move"))
                {
                    translator.PushUnityEngineGridBrushBaseTool(L, UnityEngine.GridBrushBase.Tool.Move);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Paint"))
                {
                    translator.PushUnityEngineGridBrushBaseTool(L, UnityEngine.GridBrushBase.Tool.Paint);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Box"))
                {
                    translator.PushUnityEngineGridBrushBaseTool(L, UnityEngine.GridBrushBase.Tool.Box);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pick"))
                {
                    translator.PushUnityEngineGridBrushBaseTool(L, UnityEngine.GridBrushBase.Tool.Pick);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Erase"))
                {
                    translator.PushUnityEngineGridBrushBaseTool(L, UnityEngine.GridBrushBase.Tool.Erase);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FloodFill"))
                {
                    translator.PushUnityEngineGridBrushBaseTool(L, UnityEngine.GridBrushBase.Tool.FloodFill);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.GridBrushBase.Tool!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.GridBrushBase.Tool! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineGridBrushBaseRotationDirectionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.GridBrushBase.RotationDirection), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.GridBrushBase.RotationDirection), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.GridBrushBase.RotationDirection), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Clockwise", UnityEngine.GridBrushBase.RotationDirection.Clockwise);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CounterClockwise", UnityEngine.GridBrushBase.RotationDirection.CounterClockwise);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.GridBrushBase.RotationDirection), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineGridBrushBaseRotationDirection(L, (UnityEngine.GridBrushBase.RotationDirection)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Clockwise"))
                {
                    translator.PushUnityEngineGridBrushBaseRotationDirection(L, UnityEngine.GridBrushBase.RotationDirection.Clockwise);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CounterClockwise"))
                {
                    translator.PushUnityEngineGridBrushBaseRotationDirection(L, UnityEngine.GridBrushBase.RotationDirection.CounterClockwise);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.GridBrushBase.RotationDirection!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.GridBrushBase.RotationDirection! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineGridBrushBaseFlipAxisWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.GridBrushBase.FlipAxis), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.GridBrushBase.FlipAxis), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.GridBrushBase.FlipAxis), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "X", UnityEngine.GridBrushBase.FlipAxis.X);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Y", UnityEngine.GridBrushBase.FlipAxis.Y);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.GridBrushBase.FlipAxis), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineGridBrushBaseFlipAxis(L, (UnityEngine.GridBrushBase.FlipAxis)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "X"))
                {
                    translator.PushUnityEngineGridBrushBaseFlipAxis(L, UnityEngine.GridBrushBase.FlipAxis.X);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Y"))
                {
                    translator.PushUnityEngineGridBrushBaseFlipAxis(L, UnityEngine.GridBrushBase.FlipAxis.Y);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.GridBrushBase.FlipAxis!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.GridBrushBase.FlipAxis! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUISystemProfilerApiSampleTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UISystemProfilerApi.SampleType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UISystemProfilerApi.SampleType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UISystemProfilerApi.SampleType), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Layout", UnityEngine.UISystemProfilerApi.SampleType.Layout);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Render", UnityEngine.UISystemProfilerApi.SampleType.Render);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UISystemProfilerApi.SampleType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUISystemProfilerApiSampleType(L, (UnityEngine.UISystemProfilerApi.SampleType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Layout"))
                {
                    translator.PushUnityEngineUISystemProfilerApiSampleType(L, UnityEngine.UISystemProfilerApi.SampleType.Layout);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Render"))
                {
                    translator.PushUnityEngineUISystemProfilerApiSampleType(L, UnityEngine.UISystemProfilerApi.SampleType.Render);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UISystemProfilerApi.SampleType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UISystemProfilerApi.SampleType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIGraphicRaycasterBlockingObjectsWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.GraphicRaycaster.BlockingObjects), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.GraphicRaycaster.BlockingObjects), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.GraphicRaycaster.BlockingObjects), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.UI.GraphicRaycaster.BlockingObjects.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TwoD", UnityEngine.UI.GraphicRaycaster.BlockingObjects.TwoD);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ThreeD", UnityEngine.UI.GraphicRaycaster.BlockingObjects.ThreeD);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "All", UnityEngine.UI.GraphicRaycaster.BlockingObjects.All);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.GraphicRaycaster.BlockingObjects), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIGraphicRaycasterBlockingObjects(L, (UnityEngine.UI.GraphicRaycaster.BlockingObjects)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUIGraphicRaycasterBlockingObjects(L, UnityEngine.UI.GraphicRaycaster.BlockingObjects.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TwoD"))
                {
                    translator.PushUnityEngineUIGraphicRaycasterBlockingObjects(L, UnityEngine.UI.GraphicRaycaster.BlockingObjects.TwoD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ThreeD"))
                {
                    translator.PushUnityEngineUIGraphicRaycasterBlockingObjects(L, UnityEngine.UI.GraphicRaycaster.BlockingObjects.ThreeD);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "All"))
                {
                    translator.PushUnityEngineUIGraphicRaycasterBlockingObjects(L, UnityEngine.UI.GraphicRaycaster.BlockingObjects.All);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.GraphicRaycaster.BlockingObjects!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.GraphicRaycaster.BlockingObjects! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Type), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Image.Type), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Image.Type), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Simple", UnityEngine.UI.Image.Type.Simple);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Sliced", UnityEngine.UI.Image.Type.Sliced);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Tiled", UnityEngine.UI.Image.Type.Tiled);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Filled", UnityEngine.UI.Image.Type.Filled);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Image.Type), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageType(L, (UnityEngine.UI.Image.Type)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Simple"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Simple);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sliced"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Sliced);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Tiled"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Tiled);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Filled"))
                {
                    translator.PushUnityEngineUIImageType(L, UnityEngine.UI.Image.Type.Filled);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Type!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Type! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageFillMethodWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Image.FillMethod), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Image.FillMethod), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Image.FillMethod), L, null, 6, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", UnityEngine.UI.Image.FillMethod.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", UnityEngine.UI.Image.FillMethod.Vertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Radial90", UnityEngine.UI.Image.FillMethod.Radial90);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Radial180", UnityEngine.UI.Image.FillMethod.Radial180);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Radial360", UnityEngine.UI.Image.FillMethod.Radial360);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Image.FillMethod), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageFillMethod(L, (UnityEngine.UI.Image.FillMethod)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial90"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Radial90);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial180"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Radial180);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Radial360"))
                {
                    translator.PushUnityEngineUIImageFillMethod(L, UnityEngine.UI.Image.FillMethod.Radial360);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.FillMethod!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.FillMethod! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOriginHorizontalWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", UnityEngine.UI.Image.OriginHorizontal.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", UnityEngine.UI.Image.OriginHorizontal.Right);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Image.OriginHorizontal), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOriginHorizontal(L, (UnityEngine.UI.Image.OriginHorizontal)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineUIImageOriginHorizontal(L, UnityEngine.UI.Image.OriginHorizontal.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineUIImageOriginHorizontal(L, UnityEngine.UI.Image.OriginHorizontal.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.OriginHorizontal!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.OriginHorizontal! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOriginVerticalWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", UnityEngine.UI.Image.OriginVertical.Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", UnityEngine.UI.Image.OriginVertical.Top);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Image.OriginVertical), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOriginVertical(L, (UnityEngine.UI.Image.OriginVertical)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineUIImageOriginVertical(L, UnityEngine.UI.Image.OriginVertical.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineUIImageOriginVertical(L, UnityEngine.UI.Image.OriginVertical.Top);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.OriginVertical!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.OriginVertical! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOrigin90Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Origin90), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Image.Origin90), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Image.Origin90), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomLeft", UnityEngine.UI.Image.Origin90.BottomLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopLeft", UnityEngine.UI.Image.Origin90.TopLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopRight", UnityEngine.UI.Image.Origin90.TopRight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomRight", UnityEngine.UI.Image.Origin90.BottomRight);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Image.Origin90), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOrigin90(L, (UnityEngine.UI.Image.Origin90)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "BottomLeft"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.BottomLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopLeft"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.TopLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopRight"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.TopRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomRight"))
                {
                    translator.PushUnityEngineUIImageOrigin90(L, UnityEngine.UI.Image.Origin90.BottomRight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Origin90!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Origin90! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOrigin180Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Origin180), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Image.Origin180), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Image.Origin180), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", UnityEngine.UI.Image.Origin180.Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", UnityEngine.UI.Image.Origin180.Left);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", UnityEngine.UI.Image.Origin180.Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", UnityEngine.UI.Image.Origin180.Right);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Image.Origin180), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOrigin180(L, (UnityEngine.UI.Image.Origin180)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Left);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineUIImageOrigin180(L, UnityEngine.UI.Image.Origin180.Right);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Origin180!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Origin180! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIImageOrigin360Wrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Image.Origin360), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Image.Origin360), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Image.Origin360), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Bottom", UnityEngine.UI.Image.Origin360.Bottom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Right", UnityEngine.UI.Image.Origin360.Right);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Top", UnityEngine.UI.Image.Origin360.Top);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Left", UnityEngine.UI.Image.Origin360.Left);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Image.Origin360), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIImageOrigin360(L, (UnityEngine.UI.Image.Origin360)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Bottom"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Bottom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Right"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Right);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Top"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Top);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Left"))
                {
                    translator.PushUnityEngineUIImageOrigin360(L, UnityEngine.UI.Image.Origin360.Left);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Image.Origin360!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Image.Origin360! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldContentTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.ContentType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.InputField.ContentType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.InputField.ContentType), L, null, 11, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Standard", UnityEngine.UI.InputField.ContentType.Standard);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Autocorrected", UnityEngine.UI.InputField.ContentType.Autocorrected);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IntegerNumber", UnityEngine.UI.InputField.ContentType.IntegerNumber);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DecimalNumber", UnityEngine.UI.InputField.ContentType.DecimalNumber);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Alphanumeric", UnityEngine.UI.InputField.ContentType.Alphanumeric);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Name", UnityEngine.UI.InputField.ContentType.Name);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EmailAddress", UnityEngine.UI.InputField.ContentType.EmailAddress);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Password", UnityEngine.UI.InputField.ContentType.Password);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Pin", UnityEngine.UI.InputField.ContentType.Pin);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom", UnityEngine.UI.InputField.ContentType.Custom);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.InputField.ContentType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldContentType(L, (UnityEngine.UI.InputField.ContentType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Standard"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Standard);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Autocorrected"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Autocorrected);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "IntegerNumber"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.IntegerNumber);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "DecimalNumber"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.DecimalNumber);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Alphanumeric"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Alphanumeric);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Name"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Name);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EmailAddress"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.EmailAddress);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Password"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Password);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Pin"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Pin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom"))
                {
                    translator.PushUnityEngineUIInputFieldContentType(L, UnityEngine.UI.InputField.ContentType.Custom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.ContentType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.ContentType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldInputTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.InputType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.InputField.InputType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.InputField.InputType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Standard", UnityEngine.UI.InputField.InputType.Standard);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutoCorrect", UnityEngine.UI.InputField.InputType.AutoCorrect);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Password", UnityEngine.UI.InputField.InputType.Password);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.InputField.InputType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldInputType(L, (UnityEngine.UI.InputField.InputType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Standard"))
                {
                    translator.PushUnityEngineUIInputFieldInputType(L, UnityEngine.UI.InputField.InputType.Standard);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoCorrect"))
                {
                    translator.PushUnityEngineUIInputFieldInputType(L, UnityEngine.UI.InputField.InputType.AutoCorrect);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Password"))
                {
                    translator.PushUnityEngineUIInputFieldInputType(L, UnityEngine.UI.InputField.InputType.Password);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.InputType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.InputType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldCharacterValidationWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, null, 7, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.UI.InputField.CharacterValidation.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Integer", UnityEngine.UI.InputField.CharacterValidation.Integer);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Decimal", UnityEngine.UI.InputField.CharacterValidation.Decimal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Alphanumeric", UnityEngine.UI.InputField.CharacterValidation.Alphanumeric);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Name", UnityEngine.UI.InputField.CharacterValidation.Name);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EmailAddress", UnityEngine.UI.InputField.CharacterValidation.EmailAddress);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.InputField.CharacterValidation), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldCharacterValidation(L, (UnityEngine.UI.InputField.CharacterValidation)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Integer"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Integer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Decimal"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Decimal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Alphanumeric"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Alphanumeric);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Name"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.Name);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EmailAddress"))
                {
                    translator.PushUnityEngineUIInputFieldCharacterValidation(L, UnityEngine.UI.InputField.CharacterValidation.EmailAddress);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.CharacterValidation!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.CharacterValidation! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIInputFieldLineTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.InputField.LineType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.InputField.LineType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.InputField.LineType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SingleLine", UnityEngine.UI.InputField.LineType.SingleLine);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MultiLineSubmit", UnityEngine.UI.InputField.LineType.MultiLineSubmit);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MultiLineNewline", UnityEngine.UI.InputField.LineType.MultiLineNewline);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.InputField.LineType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIInputFieldLineType(L, (UnityEngine.UI.InputField.LineType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "SingleLine"))
                {
                    translator.PushUnityEngineUIInputFieldLineType(L, UnityEngine.UI.InputField.LineType.SingleLine);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MultiLineSubmit"))
                {
                    translator.PushUnityEngineUIInputFieldLineType(L, UnityEngine.UI.InputField.LineType.MultiLineSubmit);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MultiLineNewline"))
                {
                    translator.PushUnityEngineUIInputFieldLineType(L, UnityEngine.UI.InputField.LineType.MultiLineNewline);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.InputField.LineType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.InputField.LineType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIAspectRatioFitterAspectModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.AspectRatioFitter.AspectMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.AspectRatioFitter.AspectMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.AspectRatioFitter.AspectMode), L, null, 6, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.UI.AspectRatioFitter.AspectMode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "WidthControlsHeight", UnityEngine.UI.AspectRatioFitter.AspectMode.WidthControlsHeight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "HeightControlsWidth", UnityEngine.UI.AspectRatioFitter.AspectMode.HeightControlsWidth);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FitInParent", UnityEngine.UI.AspectRatioFitter.AspectMode.FitInParent);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EnvelopeParent", UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.AspectRatioFitter.AspectMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIAspectRatioFitterAspectMode(L, (UnityEngine.UI.AspectRatioFitter.AspectMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUIAspectRatioFitterAspectMode(L, UnityEngine.UI.AspectRatioFitter.AspectMode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WidthControlsHeight"))
                {
                    translator.PushUnityEngineUIAspectRatioFitterAspectMode(L, UnityEngine.UI.AspectRatioFitter.AspectMode.WidthControlsHeight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "HeightControlsWidth"))
                {
                    translator.PushUnityEngineUIAspectRatioFitterAspectMode(L, UnityEngine.UI.AspectRatioFitter.AspectMode.HeightControlsWidth);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FitInParent"))
                {
                    translator.PushUnityEngineUIAspectRatioFitterAspectMode(L, UnityEngine.UI.AspectRatioFitter.AspectMode.FitInParent);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "EnvelopeParent"))
                {
                    translator.PushUnityEngineUIAspectRatioFitterAspectMode(L, UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.AspectRatioFitter.AspectMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.AspectRatioFitter.AspectMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUICanvasScalerScaleModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.CanvasScaler.ScaleMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.CanvasScaler.ScaleMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.CanvasScaler.ScaleMode), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ConstantPixelSize", UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPixelSize);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ScaleWithScreenSize", UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ConstantPhysicalSize", UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPhysicalSize);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.CanvasScaler.ScaleMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUICanvasScalerScaleMode(L, (UnityEngine.UI.CanvasScaler.ScaleMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "ConstantPixelSize"))
                {
                    translator.PushUnityEngineUICanvasScalerScaleMode(L, UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPixelSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ScaleWithScreenSize"))
                {
                    translator.PushUnityEngineUICanvasScalerScaleMode(L, UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ConstantPhysicalSize"))
                {
                    translator.PushUnityEngineUICanvasScalerScaleMode(L, UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPhysicalSize);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.CanvasScaler.ScaleMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.CanvasScaler.ScaleMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUICanvasScalerScreenMatchModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MatchWidthOrHeight", UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Expand", UnityEngine.UI.CanvasScaler.ScreenMatchMode.Expand);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Shrink", UnityEngine.UI.CanvasScaler.ScreenMatchMode.Shrink);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.CanvasScaler.ScreenMatchMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUICanvasScalerScreenMatchMode(L, (UnityEngine.UI.CanvasScaler.ScreenMatchMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "MatchWidthOrHeight"))
                {
                    translator.PushUnityEngineUICanvasScalerScreenMatchMode(L, UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Expand"))
                {
                    translator.PushUnityEngineUICanvasScalerScreenMatchMode(L, UnityEngine.UI.CanvasScaler.ScreenMatchMode.Expand);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Shrink"))
                {
                    translator.PushUnityEngineUICanvasScalerScreenMatchMode(L, UnityEngine.UI.CanvasScaler.ScreenMatchMode.Shrink);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.CanvasScaler.ScreenMatchMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.CanvasScaler.ScreenMatchMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUICanvasScalerUnitWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.CanvasScaler.Unit), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.CanvasScaler.Unit), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.CanvasScaler.Unit), L, null, 6, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Centimeters", UnityEngine.UI.CanvasScaler.Unit.Centimeters);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Millimeters", UnityEngine.UI.CanvasScaler.Unit.Millimeters);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Inches", UnityEngine.UI.CanvasScaler.Unit.Inches);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Points", UnityEngine.UI.CanvasScaler.Unit.Points);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Picas", UnityEngine.UI.CanvasScaler.Unit.Picas);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.CanvasScaler.Unit), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUICanvasScalerUnit(L, (UnityEngine.UI.CanvasScaler.Unit)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Centimeters"))
                {
                    translator.PushUnityEngineUICanvasScalerUnit(L, UnityEngine.UI.CanvasScaler.Unit.Centimeters);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Millimeters"))
                {
                    translator.PushUnityEngineUICanvasScalerUnit(L, UnityEngine.UI.CanvasScaler.Unit.Millimeters);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Inches"))
                {
                    translator.PushUnityEngineUICanvasScalerUnit(L, UnityEngine.UI.CanvasScaler.Unit.Inches);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Points"))
                {
                    translator.PushUnityEngineUICanvasScalerUnit(L, UnityEngine.UI.CanvasScaler.Unit.Points);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Picas"))
                {
                    translator.PushUnityEngineUICanvasScalerUnit(L, UnityEngine.UI.CanvasScaler.Unit.Picas);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.CanvasScaler.Unit!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.CanvasScaler.Unit! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIContentSizeFitterFitModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unconstrained", UnityEngine.UI.ContentSizeFitter.FitMode.Unconstrained);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MinSize", UnityEngine.UI.ContentSizeFitter.FitMode.MinSize);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PreferredSize", UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.ContentSizeFitter.FitMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIContentSizeFitterFitMode(L, (UnityEngine.UI.ContentSizeFitter.FitMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Unconstrained"))
                {
                    translator.PushUnityEngineUIContentSizeFitterFitMode(L, UnityEngine.UI.ContentSizeFitter.FitMode.Unconstrained);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MinSize"))
                {
                    translator.PushUnityEngineUIContentSizeFitterFitMode(L, UnityEngine.UI.ContentSizeFitter.FitMode.MinSize);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "PreferredSize"))
                {
                    translator.PushUnityEngineUIContentSizeFitterFitMode(L, UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.ContentSizeFitter.FitMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.ContentSizeFitter.FitMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIGridLayoutGroupCornerWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UpperLeft", UnityEngine.UI.GridLayoutGroup.Corner.UpperLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UpperRight", UnityEngine.UI.GridLayoutGroup.Corner.UpperRight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LowerLeft", UnityEngine.UI.GridLayoutGroup.Corner.LowerLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LowerRight", UnityEngine.UI.GridLayoutGroup.Corner.LowerRight);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Corner), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIGridLayoutGroupCorner(L, (UnityEngine.UI.GridLayoutGroup.Corner)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "UpperLeft"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.UpperLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "UpperRight"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.UpperRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LowerLeft"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.LowerLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LowerRight"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupCorner(L, UnityEngine.UI.GridLayoutGroup.Corner.LowerRight);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.GridLayoutGroup.Corner!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.GridLayoutGroup.Corner! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIGridLayoutGroupAxisWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", UnityEngine.UI.GridLayoutGroup.Axis.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", UnityEngine.UI.GridLayoutGroup.Axis.Vertical);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Axis), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIGridLayoutGroupAxis(L, (UnityEngine.UI.GridLayoutGroup.Axis)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupAxis(L, UnityEngine.UI.GridLayoutGroup.Axis.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupAxis(L, UnityEngine.UI.GridLayoutGroup.Axis.Vertical);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.GridLayoutGroup.Axis!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.GridLayoutGroup.Axis! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIGridLayoutGroupConstraintWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Flexible", UnityEngine.UI.GridLayoutGroup.Constraint.Flexible);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FixedColumnCount", UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FixedRowCount", UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.GridLayoutGroup.Constraint), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIGridLayoutGroupConstraint(L, (UnityEngine.UI.GridLayoutGroup.Constraint)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Flexible"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupConstraint(L, UnityEngine.UI.GridLayoutGroup.Constraint.Flexible);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FixedColumnCount"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupConstraint(L, UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FixedRowCount"))
                {
                    translator.PushUnityEngineUIGridLayoutGroupConstraint(L, UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.GridLayoutGroup.Constraint!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.GridLayoutGroup.Constraint! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUINavigationModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Navigation.Mode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Navigation.Mode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Navigation.Mode), L, null, 6, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.UI.Navigation.Mode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Horizontal", UnityEngine.UI.Navigation.Mode.Horizontal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Vertical", UnityEngine.UI.Navigation.Mode.Vertical);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Automatic", UnityEngine.UI.Navigation.Mode.Automatic);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Explicit", UnityEngine.UI.Navigation.Mode.Explicit);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Navigation.Mode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUINavigationMode(L, (UnityEngine.UI.Navigation.Mode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUINavigationMode(L, UnityEngine.UI.Navigation.Mode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Horizontal"))
                {
                    translator.PushUnityEngineUINavigationMode(L, UnityEngine.UI.Navigation.Mode.Horizontal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Vertical"))
                {
                    translator.PushUnityEngineUINavigationMode(L, UnityEngine.UI.Navigation.Mode.Vertical);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Automatic"))
                {
                    translator.PushUnityEngineUINavigationMode(L, UnityEngine.UI.Navigation.Mode.Automatic);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Explicit"))
                {
                    translator.PushUnityEngineUINavigationMode(L, UnityEngine.UI.Navigation.Mode.Explicit);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Navigation.Mode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Navigation.Mode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIScrollbarDirectionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Scrollbar.Direction), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Scrollbar.Direction), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Scrollbar.Direction), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LeftToRight", UnityEngine.UI.Scrollbar.Direction.LeftToRight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RightToLeft", UnityEngine.UI.Scrollbar.Direction.RightToLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomToTop", UnityEngine.UI.Scrollbar.Direction.BottomToTop);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopToBottom", UnityEngine.UI.Scrollbar.Direction.TopToBottom);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Scrollbar.Direction), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIScrollbarDirection(L, (UnityEngine.UI.Scrollbar.Direction)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "LeftToRight"))
                {
                    translator.PushUnityEngineUIScrollbarDirection(L, UnityEngine.UI.Scrollbar.Direction.LeftToRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RightToLeft"))
                {
                    translator.PushUnityEngineUIScrollbarDirection(L, UnityEngine.UI.Scrollbar.Direction.RightToLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomToTop"))
                {
                    translator.PushUnityEngineUIScrollbarDirection(L, UnityEngine.UI.Scrollbar.Direction.BottomToTop);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopToBottom"))
                {
                    translator.PushUnityEngineUIScrollbarDirection(L, UnityEngine.UI.Scrollbar.Direction.TopToBottom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Scrollbar.Direction!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Scrollbar.Direction! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIScrollRectMovementTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unrestricted", UnityEngine.UI.ScrollRect.MovementType.Unrestricted);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Elastic", UnityEngine.UI.ScrollRect.MovementType.Elastic);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Clamped", UnityEngine.UI.ScrollRect.MovementType.Clamped);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.ScrollRect.MovementType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIScrollRectMovementType(L, (UnityEngine.UI.ScrollRect.MovementType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Unrestricted"))
                {
                    translator.PushUnityEngineUIScrollRectMovementType(L, UnityEngine.UI.ScrollRect.MovementType.Unrestricted);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Elastic"))
                {
                    translator.PushUnityEngineUIScrollRectMovementType(L, UnityEngine.UI.ScrollRect.MovementType.Elastic);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Clamped"))
                {
                    translator.PushUnityEngineUIScrollRectMovementType(L, UnityEngine.UI.ScrollRect.MovementType.Clamped);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.ScrollRect.MovementType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.ScrollRect.MovementType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIScrollRectScrollbarVisibilityWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Permanent", UnityEngine.UI.ScrollRect.ScrollbarVisibility.Permanent);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutoHide", UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHide);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutoHideAndExpandViewport", UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.ScrollRect.ScrollbarVisibility), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, (UnityEngine.UI.ScrollRect.ScrollbarVisibility)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Permanent"))
                {
                    translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.Permanent);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoHide"))
                {
                    translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHide);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoHideAndExpandViewport"))
                {
                    translator.PushUnityEngineUIScrollRectScrollbarVisibility(L, UnityEngine.UI.ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.ScrollRect.ScrollbarVisibility!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.ScrollRect.ScrollbarVisibility! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUISelectableTransitionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Selectable.Transition), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Selectable.Transition), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Selectable.Transition), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.UI.Selectable.Transition.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ColorTint", UnityEngine.UI.Selectable.Transition.ColorTint);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SpriteSwap", UnityEngine.UI.Selectable.Transition.SpriteSwap);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Animation", UnityEngine.UI.Selectable.Transition.Animation);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Selectable.Transition), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUISelectableTransition(L, (UnityEngine.UI.Selectable.Transition)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUISelectableTransition(L, UnityEngine.UI.Selectable.Transition.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ColorTint"))
                {
                    translator.PushUnityEngineUISelectableTransition(L, UnityEngine.UI.Selectable.Transition.ColorTint);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "SpriteSwap"))
                {
                    translator.PushUnityEngineUISelectableTransition(L, UnityEngine.UI.Selectable.Transition.SpriteSwap);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Animation"))
                {
                    translator.PushUnityEngineUISelectableTransition(L, UnityEngine.UI.Selectable.Transition.Animation);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Selectable.Transition!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Selectable.Transition! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUISliderDirectionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Slider.Direction), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Slider.Direction), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Slider.Direction), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LeftToRight", UnityEngine.UI.Slider.Direction.LeftToRight);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RightToLeft", UnityEngine.UI.Slider.Direction.RightToLeft);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BottomToTop", UnityEngine.UI.Slider.Direction.BottomToTop);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopToBottom", UnityEngine.UI.Slider.Direction.TopToBottom);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Slider.Direction), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUISliderDirection(L, (UnityEngine.UI.Slider.Direction)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "LeftToRight"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.LeftToRight);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "RightToLeft"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.RightToLeft);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "BottomToTop"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.BottomToTop);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopToBottom"))
                {
                    translator.PushUnityEngineUISliderDirection(L, UnityEngine.UI.Slider.Direction.TopToBottom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Slider.Direction!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Slider.Direction! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class UnityEngineUIToggleToggleTransitionWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", UnityEngine.UI.Toggle.ToggleTransition.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Fade", UnityEngine.UI.Toggle.ToggleTransition.Fade);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.UI.Toggle.ToggleTransition), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineUIToggleToggleTransition(L, (UnityEngine.UI.Toggle.ToggleTransition)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushUnityEngineUIToggleToggleTransition(L, UnityEngine.UI.Toggle.ToggleTransition.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Fade"))
                {
                    translator.PushUnityEngineUIToggleToggleTransition(L, UnityEngine.UI.Toggle.ToggleTransition.Fade);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.UI.Toggle.ToggleTransition!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.UI.Toggle.ToggleTransition! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}