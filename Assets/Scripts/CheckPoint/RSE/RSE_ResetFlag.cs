using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_ResetFlag", menuName = "Project/RSE/ResetFlag")]
public class RSE_ResetFlag : ScriptableObject
{
    public Action Fire;
}
