using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using Object = UnityEngine.Object;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool _closing = false; 
    private static object _locked = new Object();
    private static T _instance;
    
    public static T Instance
    {
        get
        {
            if (_closing)
            {
                return null;
            }

            lock (_locked)
            {

                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>() as T;

                    if (_instance == null)
                    {
                        var singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString()+" (Singleton)";
                    }
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }

    private void OnApplicationQuit()
    {
        _closing = true;
    }

    private void OnDestroy()
    {
        _closing = true;
    }
}
   
