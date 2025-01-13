using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
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
    /// Restart the Game
    /// </summary>
    public void RestartGame()
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
