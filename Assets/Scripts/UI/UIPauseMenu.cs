using UnityEngine;
using UnityEngine.EventSystems;

public class UIPauseMenu : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    /// <summary>
    /// Load Scene Async
    /// </summary>
    /// <returns></returns>
    public void Resume()
    {
        gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Respawn Player on CheckPoint
    /// </summary>
    public void ResetGame()
    {
        gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        Time.timeScale = 1f;

        playerRespawn.Fire?.Invoke();
    }

    /// <summary>
    /// Quit the Game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
