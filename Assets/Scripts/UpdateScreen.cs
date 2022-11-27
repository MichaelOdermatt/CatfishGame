using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible updating the monitor screen
/// </summary>
public class UpdateScreen : MonoBehaviour
{
    [SerializeField]
    private UpdatePlayerInputTextMesh letterOutput;
    [SerializeField]
    private MonitorAudio montiorAudio;
    public bool isCapsLockOn;
    [SerializeField]
    private Image ScreenImage;
    [SerializeField]
    private Sprite AfterloginScreenImage;

    /// <summary>
    /// Adds the given character to the screen.
    /// </summary>
    /// <param name="character"></param>
    public void AddCharacter(string character)
    {
        letterOutput.AddCharacter(character);
    }

    public void RemoveLastChar()
    {
        letterOutput.RemoveLastChar();
    }

    public void AttemptLogin()
    {
        if (LoginPassword.IsPasswordCorrect(letterOutput.GetText()))
        {
            letterOutput.OnCorrectSubmission();
            montiorAudio.PlayAccessGrantedSound();
        }
        else
        {
            ScreenImage.sprite = AfterloginScreenImage;
            letterOutput.OnFalseSubmission();
            montiorAudio.PlayAccessDeniedSound();
        }

        letterOutput.ClearText();    
    }
}
