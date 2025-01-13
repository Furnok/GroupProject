using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_PlayerSize", menuName = "Project/RSO/PlayerSize")]
public class RSO_PlayerSize : ScriptableObject
{
    public Action<float> onValueChanged;

    [Header("Parameters")]
    [SerializeField] private float _value;

    public float Value
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
