using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    IntroDialogue dialogue;
    [SerializeField]
    private Text text;

    private void Awake()
    {
        dialogue = new IntroDialogue();
        text.text = dialogue.GetNextLine();
    }

    private void ShowNextLine()
    {
        string line = dialogue.GetNextLine();

        if (line != null)
            text.text = line;
    }
}
