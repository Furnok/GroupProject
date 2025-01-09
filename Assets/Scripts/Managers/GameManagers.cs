using UnityEngine;
using static RSO_PlayerForm;

public class GameManagers : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerPos playerPos;
    [SerializeField] private RSO_PlayerLife playerLife;
    [SerializeField] private RSE_PlayerDead playerDead;
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    [Header("Parameters")]
    [SerializeField] private int lifeMax;

    private bool isDead;

    private void OnEnable()
    {
        playerLife.onValueChanged += LoseLife;
    }

    private void OnDisable()
    {
        playerForm.Value = Forms.Human;
        playerPos.Value = Vector3.zero;
        playerLife.Value = lifeMax;

        playerLife.onValueChanged -= LoseLife;
    }

    /// <summary>
    /// The Player Lose a Life
    /// </summary>
    /// <param name="life"></param>
    private void LoseLife(int life)
    {
        if(!isDead)
        {
            life -= Mathf.Clamp(1, 0, lifeMax);

            if (life <= 0)
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

        playerDead.Fire?.Invoke();
    }
}
