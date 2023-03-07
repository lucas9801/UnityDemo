/*
 * 简单monobehaiour的实现 test版
 */
using System;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using UnityEngine;
public class ILRuntimeMonoBehaviour : MonoBehaviour
{
    public string hotfixScript;
    private IType type;
    public void Awake()
    {
        if (string.IsNullOrEmpty(hotfixScript)) hotfixScript = "Hotfix.HotfixTestClass";
        type = ILRuntimeManager.Instance.GetAppDomain().LoadedTypes[hotfixScript];
        IMethod method = type.GetMethod("Awake", 0);
        ILRuntimeManager.Instance.GetAppDomain().Invoke(method, null);
    }
    
    public void OnEnable()
    {
        IMethod method = type.GetMethod("OnEnable", 0);
        ILRuntimeManager.Instance.GetAppDomain().Invoke(method, null);
    }
    
    public void Start()
    {
        IMethod method = type.GetMethod("Start", 0);
        ILRuntimeManager.Instance.GetAppDomain().Invoke(method, null);
    }
    
    public void Update()
    {
        IMethod method = type.GetMethod("Update", 0);
        ILRuntimeManager.Instance.GetAppDomain().Invoke(method, null);
    }
    
    public void OnDisable()
    {
        IMethod method = type.GetMethod("OnDisable", 0);
        ILRuntimeManager.Instance.GetAppDomain().Invoke(method, null);
    }
    
    public void OnDestroy()
    {
        IMethod method = type.GetMethod("OnDestroy", 0);
        ILRuntimeManager.Instance.GetAppDomain().Invoke(method, null);
    }
}
