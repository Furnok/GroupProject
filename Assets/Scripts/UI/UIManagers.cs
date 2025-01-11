using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIManagers : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerDead playerDead;
    [SerializeField] private RSE_FinishGame finishGame;

    [Header("References")]
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject menuGameWin;

    private void OnEnable()
    {
        playerDead.Fire += GameOver;
        finishGame.Fire += GameWin;
    }

    private void OnDisable()
    {
        playerDead.Fire -= GameOver;
        finishGame.Fire -= GameWin;
    }

    /// <summary>
    /// Game Over UI
    /// </summary>
    private void GameOver()
    {
        menuGameOver.SetActive(true);
    }

    /// <summary>
    /// Game Win UI
    /// </summary>
    private void GameWin()
    {
        menuGameWin.SetActive(true);
    }

    /// <summary>
    /// Pause Menu Call by the Player Input on this gameObject
    /// </summary>
    /// <param name="ctx"></param>
    public void PauseMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!menuPause.activeInHierarchy)
            {
                menuPause.SetActive(true);

                Time.timeScale = 0f;
            }
            else
            {
                menuPause.SetActive(false);

                EventSystem.current.SetSelectedGameObject(null);

                Time.timeScale = 1f;
            }
        }
    }
}
