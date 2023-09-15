using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/EventChannels/VoidEventChannel", fileName = "VoidChannel")]
public class VoidEventChannel : ScriptableObject
{
    event Action Delegate;

    public void BoardCast()
    {
        Delegate?.Invoke();
    }

    public void AddListen(Action action)
    {
        Delegate += action;
    }
    public void RemoveListen(Action action)
    {
        Delegate -= action;
    }
}
