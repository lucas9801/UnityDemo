using System.Collections;
using UnityEngine;

public class HotFix
{
    private WaitForSeconds wait = new WaitForSeconds(1.0f);
    public void HotFixTest()
    {
        DebugL8.LogError("C# HotFix");
    }

    IEnumerator HotFixCor()
    {
        while (true)
        {
            yield return wait;
            DebugL8.LogError("C# Coroutine");   
        }
    }
}