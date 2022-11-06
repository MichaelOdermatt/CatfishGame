using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Responsible updating the monitor screen
/// </summary>
public class UpdateScreen : MonoBehaviour
{
    [SerializeField]
    private UpdatePlayerInputTextMesh letterOutput;
    public bool isCapsLockOn;

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
        letterOutput.ClearText();    
    }
}
