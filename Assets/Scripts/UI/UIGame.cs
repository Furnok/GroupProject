using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerLife playerLife;

    [Header("References")]
    [SerializeField] private Sprite hearthEmpty;
    [SerializeField] private Sprite hearthFull;
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    private void OnEnable()
    {
        playerLife.onValueChanged += LoseHearth;
    }

    private void OnDisable()
    {
        playerLife.onValueChanged -= LoseHearth;
    }

    /// <summary>
    /// Lose a Heart in the UI
    /// </summary>
    /// <param name="life"></param>
    private void LoseHearth(int life)
    {
        if (life == 2)
        {
            heart3.sprite = hearthEmpty;
        }
        else if (life == 1)
        {
            heart2.sprite = hearthEmpty;
        }
        else if (life == 0)
        {
            heart1.sprite = hearthEmpty;
        }
    }
}
