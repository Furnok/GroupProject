using UnityEngine;
using UnityEngine.EventSystems;

public class UIPauseMenu : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    public void Resume()
    {
        gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        Time.timeScale = 1f;
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        Time.timeScale = 1f;

        playerRespawn.Fire?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
