using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextGame : MonoBehaviour
{
    [SerializeField] TMP_Text gameText;
    [SerializeField] TMP_Text titleText;

    [SerializeField] State startingState;
    [SerializeField] State endingState;
    [SerializeField] State axeState;

    [SerializeField] Sprite axeImage;
    [SerializeField] Sprite deathImage;
    [SerializeField] Sprite vicotryImage;

    [SerializeField] Player player;

    [SerializeField] Image currentImage;
    [SerializeField] Image axeImageObject;

    State state;

    void Start()
    {
        state = startingState;

        axeImageObject.gameObject.SetActive(false);

        EnterState();
    }

    void Update()
    {
        ManageStates();
    }

    void ManageStates()
    {
        var nextStates = state.GetNextStates();

        if (Keyboard.current.anyKey.wasPressedThisFrame && state == startingState)
        {
            titleText.text = "";
            state = nextStates[0];

            gameText.alignment = TextAlignmentOptions.TopLeft;
            EnterState();
            return;
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            if (nextStates.Length > 0)
            {
                state = nextStates[0];
                EnterState();
            }
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            if (nextStates.Length > 1)
            {
                state = nextStates[1];
                EnterState();
            }
        }
    }


    void EnterState()
    {
        axeImageObject.gameObject.SetActive(false);

        if (state == axeState)
        {
            player.SetAxe(true);

            axeImageObject.gameObject.SetActive(true);
            axeImageObject.sprite = axeImage;
        }

        if (state == endingState)
        {
            if (!player.GetAxe())
            {
                gameText.text = "You died. Try finding a weapon.\n1. Restart GAME";
                currentImage.sprite = deathImage;
                return;
            }
        }

        gameText.text = state.GetStoryText();
        currentImage.sprite = state.GetCurrentImage();
    }
}