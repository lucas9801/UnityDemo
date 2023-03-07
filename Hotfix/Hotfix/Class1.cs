using UnityEngine;

namespace Hotfix
{
    public class HotfixTestClass
    {
        public static void Ctor()
        {
            //Debug.LogError("Hotfix Test");
            //GameObject obj = new GameObject("ILRuntimeTest");
            //ILRuntimeMonoBehaviour mono = obj.AddComponent<ILRuntimeMonoBehaviour>();
            //mono.awake = Awake;
            //mono.start = Start;
            //mono.update = Update;
            //mono.onDestroy = OnDestroy;
        }

        static void Awake()
        {
            Debug.LogError("Awake");
        }

        static void Start()
        {
            Debug.LogError("Start");
        }

        static void Update()
        {
            Debug.LogError("Update");
        }

        static void OnDestroy()
        {
            Debug.LogError("OnDestroy");
        }

        void HotfixDebugTest()
        {
            Debug.LogError("HotfixTest__Debug");
        }
    }
}
