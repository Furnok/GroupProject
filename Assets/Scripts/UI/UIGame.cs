using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static RSO_PlayerForm;

public class UIGame : MonoBehaviour
{
    [Header("Output Data")]
    [SerializeField] private RSO_PlayerForm playerForm;
    [SerializeField] private RSO_PlayerLife playerLife;

    [Header("References")]
    [SerializeField] private Sprite hearthEmpty;
    [SerializeField] private Sprite hearthFull;

    [SerializeField] private List<Image> hearts;

    [SerializeField] private List<TextMeshProUGUI> inputs;

    [Header("Parameters")]
    [SerializeField] private List<string> listinputHuman;
    [SerializeField] private List<string> listinputBird;
    [SerializeField] private List<string> listinputMouse;

    private void OnEnable()
    {
        playerForm.onValueChanged += InitialiseText;
        playerLife.onValueChanged += LoseHearth;
    }

    private void OnDisable()
    {
        playerForm.onValueChanged -= InitialiseText;
        playerLife.onValueChanged -= LoseHearth;
    }

    private void Start()
    {
        InitialiseText(playerForm.Value);
    }

    /// <summary>
    /// Initialise the Text of Input on the UI
    /// </summary>
    private void InitialiseText(Forms form)
    {
        if (playerForm.Value == Forms.Human)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                if (listinputHuman[i] != null)
                {
                    inputs[i].gameObject.SetActive(true);
                    inputs[i].text = listinputHuman[i];
                }
                else
                {
                    inputs[i].gameObject.SetActive(false);
                }
            }
        }
        else if (playerForm.Value == Forms.Bird)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                if (listinputBird[i] != "")
                {
                    inputs[i].gameObject.SetActive(true);
                    inputs[i].text = listinputBird[i];
                }
                else
                {
                    inputs[i].gameObject.SetActive(false);
                }
            }
        }
        else if (playerForm.Value == Forms.Mouse)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                if (listinputMouse[i] != "")
                {
                    inputs[i].gameObject.SetActive(true);
                    inputs[i].text = listinputMouse[i];
                }
                else
                {
                    inputs[i].gameObject.SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// Lose a Heart in the UI
    /// </summary>
    /// <param name="life"></param>
    private void LoseHearth(int life)
    {
        if (life == 2)
        {
            hearts[2].sprite = hearthEmpty;
        }
        else if (life == 1)
        {
            hearts[1].sprite = hearthEmpty;
        }
        else if (life == 0)
        {
            hearts[0].sprite = hearthEmpty;
        }
    }
}
