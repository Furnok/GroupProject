using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIManagers : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSE_PlayerDead playerDead;

    [Header("References")]
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuGameOver;

    private void OnEnable()
    {
        playerDead.Fire += GameOver;
    }

    private void OnDisable()
    {
        playerDead.Fire -= GameOver;
    }

    /// <summary>
    /// Game Over UI
    /// </summary>
    private void GameOver()
    {
        menuGameOver.SetActive(true);
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
