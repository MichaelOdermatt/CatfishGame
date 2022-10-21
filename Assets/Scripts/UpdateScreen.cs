using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Soley responsible for updating the TextMeshPro object
/// </summary>
public class UpdateScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro letterOutput;
    public bool isCapsLockOn;

    /// <summary>
    /// Adds the given character to the screen.
    /// </summary>
    /// <param name="character"></param>
    public void AddCharacter(string character)
    {
        letterOutput.text += character;
    }

    public void RemoveLastChar()
    {
        string input = letterOutput.text;
        letterOutput.text = input.Remove(input.Length - 1);
    }
}