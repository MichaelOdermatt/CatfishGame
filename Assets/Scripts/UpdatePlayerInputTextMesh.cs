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
    private Color initialTextMeshColor;
    [SerializeField]
    private float failedSubmissionEffectDuration;
    [SerializeField]
    private float failedSubmissionShakeMagnitude;

    private bool stopUpdatingTextMesh;
    private string falseSubmissionText = "XXXX";

    private void Start()
    {
        initialTextMeshColor = textMesh.color;
        blinkingTextCursor = new BlinkingTextCursor();
        StartCoroutine(ExecuteAfterTime.Exectute(ContinuouslyToggleUseStringWithCursor, blinkingTextCursor.cursorBlinkFrequency));
    }

    void Update()
    {
        if (stopUpdatingTextMesh)
        {
            return;
        }

        var newText = blinkingTextCursor.GetOutputString();
        if (textMesh.text != newText)
        {
            textMesh.text = newText;
        }
    }

    public void AddCharacter(string character)
    {
        // prevent the first character from being a space to avoid confusion
        if (character == " " && blinkingTextCursor.GetRawString() == "")
            return;

        blinkingTextCursor.AddChar(character);
    }

    public void RemoveLastChar()
    {
        blinkingTextCursor.RemoveLastChar();
    }

    public void ClearText()
    {
        blinkingTextCursor.ClearText(); 
    }

    public string GetText()
    {
        return blinkingTextCursor.GetRawString();
    }

    public void ContinuouslyToggleUseStringWithCursor()
    {
        blinkingTextCursor.ToggleUseCursor();
        StartCoroutine(ExecuteAfterTime.Exectute(ContinuouslyToggleUseStringWithCursor, blinkingTextCursor.cursorBlinkFrequency));
    }

    public void OnFalseSubmission()
    {
        SetFalseSubmissionProperties();
        StartCoroutine(ExecuteAfterTime.Exectute(ResetFalseSubmissionProperties, failedSubmissionEffectDuration));
        StartCoroutine(ObjectShake.Shake(textMesh.transform, failedSubmissionEffectDuration, failedSubmissionShakeMagnitude));
    }

    private void SetFalseSubmissionProperties()
    {
        textMesh.color = Color.red;
        stopUpdatingTextMesh = true;
        textMesh.text = falseSubmissionText;
    }

    private void ResetFalseSubmissionProperties()
    {
        textMesh.color = initialTextMeshColor;
        stopUpdatingTextMesh = false;
        textMesh.text = "";
    }
}
