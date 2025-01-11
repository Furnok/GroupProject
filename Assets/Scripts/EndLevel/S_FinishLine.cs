using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_FinishLine : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_FinishGame finishGame;

    [Header("Parameters")]
    [SerializeField] private bool isEndGame;
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
            if (!isEndGame)
            {
                Time.timeScale = 0f;

                ao = SceneManager.LoadSceneAsync(sceneName);
                ao.allowSceneActivation = false;

                StartCoroutine(LoadScene());
            }
            else
            {
                Time.timeScale = 0f;

                finishGame.Fire?.Invoke();
            }
        }
    }
}
