using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_PlayerLife", menuName = "Project/RSO/PlayerLife")]
public class RSO_PlayerLife : ScriptableObject
{
    public Action<int> onValueChanged;

    [Header("Parameters")]
    [SerializeField] private int _value;

    public int Value
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
