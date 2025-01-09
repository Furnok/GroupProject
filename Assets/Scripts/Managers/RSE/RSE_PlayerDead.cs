using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerDead", menuName = "Project/RSE/PlayerDead")]
public class RSE_PlayerDead : ScriptableObject
{
    public Action Fire;
}
