using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using UnityEngine;
using UnityEngine.Networking;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using UnityEngine.Events;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

/*
 个人觉得ILRuntime热更新 对项目的结构影响比较大，构建比较麻烦，但是性能肯定是比XLua高
 但是综合还是XLua比较适合 项目初期可以使用XLua进行Hotfix 后续项目稳定可以关闭XLua热更新，使用纯Lua热更新
 其实这两个热更新原理都是对IL进行修改 只是一个需要跨语言 性能上稍差些
    1.寄存器模式
    2.委托适配器（跨域委托） 委托转化器
    3.继承适配器（跨域继承）
    4.CLR重定向与CLR绑定
    5.显式调用泛型
*/

public class ILRuntimeManager : MonoBehaviour
{
    private AppDomain appDomain;

    private System.IO.MemoryStream fs;

    private System.IO.MemoryStream p;

    private static ILRuntimeManager instance;
    
    public static ILRuntimeManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        if (appDomain == null) appDomain = new ILRuntime.Runtime.Enviorment.AppDomain();
        StartCoroutine(LoadHotFixAssembly());
        appDomain.DelegateManager.RegisterMethodDelegate<int>();
        appDomain.DelegateManager.RegisterDelegateConvertor<UnityAction>
        (
            (act) =>
            {
                return new UnityAction(() =>
                    ((Action)act)());

            }
        );
        Test();
    }
    
    public AppDomain GetAppDomain()
    {
        return appDomain;
    }

    //方法重定义
    unsafe void Test()
    {
        var mi = typeof(Debug).GetMethod("Log", new System.Type[] { typeof(object) });
        appDomain.RegisterCLRMethodRedirection(mi, DLog);
    }
    
    public unsafe static StackObject* DLog(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
    {
        ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
        StackObject* ptr_of_this_method;
        //只有一个参数，所以返回指针就是当前栈指针ESP - 1
        StackObject* __ret = ILIntepreter.Minus(__esp, 1);
        //第一个参数为ESP -1， 第二个参数为ESP - 2，以此类推
        ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
        //获取参数message的值
        object message = StackObject.ToObject(ptr_of_this_method, __domain, (IList<object>)__mStack);
        //需要清理堆栈
        __intp.Free(ptr_of_this_method);
        //如果参数类型是基础类型，例如int，可以直接通过int param = ptr_of_this_method->Value获取值，
        //关于具体原理和其他基础类型如何获取，请参考ILRuntime实现原理的文档。

        //通过ILRuntime的Debug接口获取调用热更DLL的堆栈
        string stackTrace = __domain.DebugService.GetStackTrace(__intp);
        Debug.Log(string.Format("{0}\n----------------\n{1}", message, stackTrace));

        return __ret;
    }

    IEnumerator LoadHotFixAssembly()
    {
#if UNITY_ANDROID
        
#else
        // WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/HotFix" + "/HotFix.dll");
        UnityWebRequest req = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/Hotfix" + "/Hotfix.dll");
#endif
        // while (!www.isDone) yield return null;
        // while (!req.isDone) yield return null;
        yield return req.SendWebRequest();
        if (!string.IsNullOrEmpty(req.error)) DebugL8.LogError(req.error);
        byte[] dll = req.downloadHandler.data;
        req.Dispose();

#if UNITY_ANDROID
#else
        req = UnityWebRequest.Get("file:///" + Application.streamingAssetsPath + "/Hotfix" + "/Hotfix.pdb");
#endif
        yield return req.SendWebRequest();
        if (!string.IsNullOrEmpty(req.error)) DebugL8.LogError(req.error);
        byte[] pdb = req.downloadHandler.data;
        fs = new MemoryStream(dll);
        p = new MemoryStream(pdb);
        try
        {
            appDomain.LoadAssembly(fs, p, new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());
            // appDomain.LoadAssembly(fs, p, null);
        }
        catch
        {
            DebugL8.LogError("加载热更DLL失败");
        }
        req.Dispose();
        OnHotFixLoaded();
    }

    void OnHotFixLoaded()
    {
        GameObject obj = new GameObject("ILTest");
        ILRuntimeMonoBehaviour behaviour = obj.AddComponent<ILRuntimeMonoBehaviour>();
        // IType type = appDomain.LoadedTypes["Hotfix.HotfixTestClass"];
        // IMethod method = type.GetMethod("HotfixTest", 0);
        // appDomain.Invoke(method, null);
        // appDomain.Invoke("Hotfix.HotfixTestClass", "HotfixTest", null, null);
        // object obj = appDomain.Instantiate("Hotfix.HotfixTestClass");
        // appDomain.Invoke("Hotfix.HotfixTestClass", "HotfixDebugTest", obj);
    }
}
