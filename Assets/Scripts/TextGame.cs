using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;

public class TextGame : MonoBehaviour
{
    [SerializeField] TMP_Text gameText;
    [SerializeField] TMP_Text titleText;
    [SerializeField] State startingState;
    [SerializeField] Image currentImage;

    State state;

    private void Start()
    {
        state = startingState;
        gameText.text = state.GetStoryText();
        titleText.text = "Peasant's Freedom";
        currentImage.sprite = state.GetCurrentImage();
    }
    void Update()
    {
        ManageStates();
    }

    private void ManageStates()
    {
        var nextStates = state.GetNextStates();
        if (Keyboard.current.anyKey.wasPressedThisFrame && state == startingState)
        {
            titleText.text = "";
            state = nextStates[0];

            gameText.alignment = TextAlignmentOptions.TopLeft;
        }
        else if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            state = nextStates[0];
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            state = nextStates[1];
        }

        gameText.text = state.GetStoryText();
        currentImage.sprite = state.GetCurrentImage();
    }
}
