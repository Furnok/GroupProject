using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerRespawn playerRespawn;

    [Header("Parameters")]
    [SerializeField] private string sceneName;
    [SerializeField] private float loadTime;

    private AsyncOperation ao;
    private bool isButtonPressed;

    /// <summary>
    /// Load Scene Async
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadScene()
    {
        yield return new WaitForSecondsRealtime(loadTime);

        Time.timeScale = 1f;

        ao.allowSceneActivation = true;
    }

    /// <summary>
    /// Load Scene Async
    /// </summary>
    /// <returns></returns>
    public void Resume()
    {
        if(!isButtonPressed)
        {
            isButtonPressed = true;

            gameObject.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);

            Time.timeScale = 1f;
        }
    }

    /// <summary>
    /// Respawn Player on CheckPoint
    /// </summary>
    public void ResetGame()
    {
        if (!isButtonPressed)
        {
            isButtonPressed = true;

            gameObject.SetActive(false);

            EventSystem.current.SetSelectedGameObject(null);

            Time.timeScale = 1f;

            playerRespawn.Fire?.Invoke();
        }
    }

    /// <summary>
    /// Go to the Menu
    /// </summary>
    public void MainMenu()
    {
        if (!isButtonPressed)
        {
            isButtonPressed = true;

            EventSystem.current.SetSelectedGameObject(null);

            ao = SceneManager.LoadSceneAsync(sceneName);
            ao.allowSceneActivation = false;

            StartCoroutine(LoadScene());
        }
    }

    /// <summary>
    /// Quit the Game
    /// </summary>
    public void QuitGame()
    {
        if (!isButtonPressed)
        {
            isButtonPressed = true;

            Application.Quit();
        }
    }
}
