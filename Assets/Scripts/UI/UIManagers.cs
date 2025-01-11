using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIManagers : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject menuPause;

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
