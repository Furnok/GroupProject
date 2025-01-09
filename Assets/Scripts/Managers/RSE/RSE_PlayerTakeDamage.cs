using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_PlayerTakeDamage", menuName = "Project/RSE/PlayerTakeDamage")]
public class RSE_PlayerTakeDamage : ScriptableObject
{
    public Action Fire;
}
