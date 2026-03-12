using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(13, 10)][SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] Sprite currentImage;

    public string GetStoryText()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public Sprite GetCurrentImage()
    {
        return currentImage;
    }
}
