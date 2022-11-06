using TMPro;
using UnityEngine;

/// <summary>
/// Responsible for updating the player input text mesh
/// </summary>
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
        blinkingTextCursor.ToggleUseCursor();
        StartCoroutine(ExecuteAfterTime.Exectute(ContinuouslyToggleUseStringWithCursor, blinkingTextCursor.cursorBlinkFrequency));
    }

    public void ClearText()
    {
        blinkingTextCursor.ClearText(); 
    }
}
