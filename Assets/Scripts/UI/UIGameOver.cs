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

    private IEnumerator LoadScene()
    {
        yield return new WaitForSecondsRealtime(loadTime);

        Time.timeScale = 1f;

        ao.allowSceneActivation = true;
    }

    public void RestartGame()
    {
        EventSystem.current.SetSelectedGameObject(null);

        ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;

        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
