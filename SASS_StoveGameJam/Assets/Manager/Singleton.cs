using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T _instance;
    public static T In { get { return _instance; } }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        OnAwake();
    }
    protected virtual void OnAwake() { }
    protected virtual void OnDestroy()
    {
        _instance = null;
    }
    public static bool HasInstance
    {
        get { return In != null; }
    }
}