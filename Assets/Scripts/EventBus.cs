using System;
using System.Collections;
using System.Collections.Generic;

public class EventBus
{
    private Dictionary<string, List<Action<object>>> _eventListeners;

    private static EventBus _instance;
    public static EventBus Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventBus();
            }
            return _instance;
        }
    }

    private EventBus()
    {
        _eventListeners = new Dictionary<string, List<Action<object>>>();
    }

    public void RegisterEvent(string eventName, Action<object> listener)
    {
        if (!_eventListeners.ContainsKey(eventName))
        {
            _eventListeners[eventName] = new List<Action<object>>();
        }

        _eventListeners[eventName].Add(listener);
    }

    public void UnregisterEvent(string eventName, Action<object> listener)
    {
        if (_eventListeners.ContainsKey(eventName))
        {
            _eventListeners[eventName].Remove(listener);
        }
    }

    public void TriggerEvent(string eventName, object data)
    {
        if (_eventListeners.ContainsKey(eventName))
        {
            foreach (Action<object> listener in _eventListeners[eventName])
            {
                listener.Invoke(data);
            }
        }
    }
}