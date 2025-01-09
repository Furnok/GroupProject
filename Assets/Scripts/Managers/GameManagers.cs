using UnityEngine;
using static RSO_PlayerForm;

public class GameManagers : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerPos playerPos;
    [SerializeField] private RSO_PlayerLife playerLife;

    private void OnDisable()
    {
        playerForm.Value = Forms.Human;
        playerPos.Value = Vector3.zero;
        playerLife.Value = 3;
    }
}
