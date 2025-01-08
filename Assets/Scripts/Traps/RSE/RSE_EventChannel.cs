using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_EventChannel", menuName = "Project/RSE/EventChannel")]
public class RSE_EventChannel : ScriptableObject
{
    private Action onEventRaised;

    public void RegisterListener(Action listener)
    {
        onEventRaised += listener;
    }

    public void UnregisterListener(Action listener)
    {
        onEventRaised -= listener;
    }

    public void RaiseEvent()
    {
        onEventRaised?.Invoke();
    }
}
