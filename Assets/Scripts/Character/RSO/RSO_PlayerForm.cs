using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_PlayerForm", menuName = "Project/RSO/PlayerForm")]
public class RSO_PlayerForm : ScriptableObject
{
    public enum Forms
    {
        Human,
        Bird,
        Mouse,
    }

    public Action<Forms> onValueChanged;

    [Header("Parameters")]
    [SerializeField] private Forms _value;

    public Forms Value
    {
        get => _value;
        set
        {
            if (_value == value) return;

            _value = value;

            onValueChanged?.Invoke(_value);
        }
    }
}
