using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{
    protected static T _instance = null;
    public static T instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = GameObject.FindObjectOfType<T>() as T;
                if(_instance==null)
                {
                    _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                }
            }

            return _instance;
        }
    }

}
