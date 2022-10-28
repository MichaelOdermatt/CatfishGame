using TMPro;
using UnityEngine;

public class UpdatePlayerInputTextMesh : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMesh;
    private BlinkingTextCursor blinkingTextCursor;

    private void Start()
    {
        blinkingTextCursor = new BlinkingTextCursor();
        StartCoroutine(ExecuteAfterTime.Exectute(ContinuouslyToggleUseStringWithCursor, blinkingTextCursor.cursorBlinkFrequency));
    }

    void Update()
    {
        var newText = blinkingTextCursor.GetOutputString();
        if (textMesh.text != newText)
        {
            textMesh.text = newText;
        }
    }

    public void AddCharacter(string character)
    {
        blinkingTextCursor.AddChar(character);
    }

    public void RemoveLastChar()
    {
        blinkingTextCursor.RemoveLastChar();
    }

    public void ContinuouslyToggleUseStringWithCursor()
    {
        blinkingTextCursor.useStringWithCursor = !blinkingTextCursor.useStringWithCursor;
        StartCoroutine(ExecuteAfterTime.Exectute(ContinuouslyToggleUseStringWithCursor, blinkingTextCursor.cursorBlinkFrequency));
    }
}
