using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private string sceneName;
    [SerializeField] private float loadTime;

    private AsyncOperation ao;
    private bool isButtonPressed;

    private void OnEnable()
    {
        isButtonPressed = false;
    }

    /// <summary>
    /// Load Scene Async
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadScene()
    {
        yield return new WaitForSecondsRealtime(loadTime);

        ao.allowSceneActivation = true;
    }

    /// <summary>
    /// Start the Game
    /// </summary>
    public void StartGame()
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
