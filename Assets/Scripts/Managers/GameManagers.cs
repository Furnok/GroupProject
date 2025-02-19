using System.Collections;
using UnityEngine;
using static RSO_PlayerForm;

public class GameManagers : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerPos playerPos;
    [SerializeField] private RSO_PlayerLife playerLife;
    [SerializeField] private RSO_RespawnPoint respawnPoint;
    [SerializeField] private RSE_PlayerTakeDamage playerTakeDamage;
    [SerializeField] private RSE_PlayerDead playerDead;
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    [Header("Parameters")]
    [SerializeField] private int lifeMax;
    [SerializeField] private float timeInvincibility;

    private bool isDead;
    private bool isInvincible;

    private void OnEnable()
    {
        playerTakeDamage.Fire += LoseLife;
    }

    private void OnDisable()
    {
        playerForm.Value = Forms.Human;
        playerLife.Value = 3;
        playerPos.Value = Vector3.zero;
        respawnPoint.Value = Vector3.zero;

        playerTakeDamage.Fire -= LoseLife;
    }

    /// <summary>
    /// Player is Invincible for a short Time
    /// </summary>
    /// <returns></returns>
    private IEnumerator ReloadLoseLife()
    {
        isInvincible = true;

        yield return new WaitForSecondsRealtime(timeInvincibility);

        isInvincible = false;
    }

    /// <summary>
    /// The Player Lose a Life
    /// </summary>
    /// <param name="life"></param>
    private void LoseLife(int damage)
    {
        if(!isInvincible)
        {
            playerLife.Value = Mathf.Max(playerLife.Value - damage, 0);

            StartCoroutine(ReloadLoseLife());

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
