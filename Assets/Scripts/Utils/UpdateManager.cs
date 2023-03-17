using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class UpdateManager : MonoBehaviour
{
    private static bool m_isApplicationQuit = false;
    private static Object m_lock = new Object();
    private static UpdateManager m_instance;

    private static void CreateInstance()
    {
        if (m_isApplicationQuit) return;
        lock (m_lock)
        {
            if (null == m_instance)
            {
                var go = new GameObject(typeof(UpdateManager).ToString());
                DontDestroyOnLoad(go);
                m_instance = go.AddComponent<UpdateManager>();
            }
        }
    }

    private static LinkedList<Action> m_updateList = new LinkedList<Action>();

    public static void RegisterUpdate(Action update)
    {
        if (null == m_instance) CreateInstance();
        m_updateList.AddLast(update);
    }

    public static void UnRegisterUpdate(Action update)
    {
        m_updateList.Remove(update);
    }

    private LinkedListNode<Action> m_curNode;
    private void Update()
    {
        m_curNode = m_updateList.First;
        while (null != m_curNode)
        {
            m_curNode?.Value();
            m_curNode = m_curNode.Next;
        }
    }

    private void OnDestroy()
    {
        m_isApplicationQuit = false;
    }
}