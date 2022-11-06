using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Responsible updating the monitor screen
/// </summary>
public class UpdateScreen : MonoBehaviour
{
    [SerializeField]
    private UpdatePlayerInputTextMesh letterOutput;
    public bool isCapsLockOn;
    // should this be stored in its own class along with a method
    // for cheking password correctness?
    public string loginScreenPassword = "B6m3";
    [SerializeField]
    private Image ScreenImage;

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

    public void ClearScreen()
    {
        if (loginScreenPassword == letterOutput.GetText())
            // update the screen Image

        letterOutput.ClearText();    
    }
}
