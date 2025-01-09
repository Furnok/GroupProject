using UnityEngine;
using static RSO_PlayerForm;

public class GameManagers : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerPos playerPos;
    [SerializeField] private RSO_PlayerLife playerLife;
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;
    [SerializeField] private RSE_PlayerDead playerDead;
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    [Header("Parameters")]
    [SerializeField] private int lifeMax;

    private bool isDead;

    private void OnEnable()
    {
        playerTakeDamage.Fire += LoseLife;
    }

    private void OnDisable()
    {
        playerForm.Value = Forms.Human;
        playerPos.Value = Vector3.zero;

        playerTakeDamage.Fire -= LoseLife;
    }

    /// <summary>
    /// The Player Lose a Life
    /// </summary>
    /// <param name="life"></param>
    private void LoseLife()
    {
        playerLife.Value = Mathf.Max(playerLife.Value - 1, 0);

        if (!isDead)
        {
            if (playerLife.Value <= 0)
            {
                GameOver();
            }
            else
            {
                playerRespawn.Fire?.Invoke();
            }
        }
    }

    /// <summary>
    /// The Player Lose all is Life
    /// </summary>
    private void GameOver()
    {
        isDead = true;

        Time.timeScale = 0f;

        playerDead.Fire?.Invoke();
    }
}
