using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_FinishLine : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private string sceneName;
    [SerializeField] private float loadTime;

    private AsyncOperation ao;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;

            ao = SceneManager.LoadSceneAsync(sceneName);
            ao.allowSceneActivation = false;

            StartCoroutine(LoadScene());
        }
    }
}
