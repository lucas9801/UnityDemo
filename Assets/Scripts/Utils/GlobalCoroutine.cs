using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalCoroutine
{
    public static Coroutine StartCoroutine(IEnumerator routine)
    {
        if(s_oEngineObj == null) { InitStaticInstance(); }

        Coroutine oRet = s_oEngineBehaviour.StartCoroutine( routine );
        return oRet;
    }

    public static void StopCoroutine(Coroutine routine)
    {
        if(s_oEngineObj == null) { InitStaticInstance(); }

        s_oEngineBehaviour.StopCoroutine(routine);
    }

    public static Coroutine NoGCRunCoroutine(IEnumerator routine)
    {
        if(s_oEngineObj == null) { InitStaticInstance(); }
        return s_oEngineBehaviour.StartCoroutine(routine);
    }

    private class EngineBehaviour : MonoBehaviour
    {
    }
    private static GameObject s_oEngineObj = null;
    private static EngineBehaviour s_oEngineBehaviour = null;

    private static void InitStaticInstance()
    {
        s_oEngineObj = new GameObject("GlobalCoroutine");
        GameObject.DontDestroyOnLoad(s_oEngineObj);
        s_oEngineBehaviour = s_oEngineObj.AddComponent<EngineBehaviour>();
    }
}