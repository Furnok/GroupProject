using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_RespawnPoint", menuName = "Project/RSO/RespawnPoint")]
public class RSO_RespawnPoint : ScriptableObject
{
    public Action<Vector3> onValueChanged;

    [Header("Parameters")]
    [SerializeField] private Vector3 _value;

    public Vector3 Value
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
