using UnityEngine;

public class BlinkingTextCursor : MonoBehaviour
{
    public string cursorSymbol = "|";
    public string withoutCursorSymbol = "<color=#00000000>|</color>";
    // rawString only contains the characters inputed by the player
    private string rawString = "";
    private string withCursor = "";
    private string withoutCursor = "";
    // gets updated every 0.5 seconds to represent if the output string will contain the cursor
    private bool useStringWithCursor = true;
    public float cursorBlinkFrequency = 0.5f;

    /// <summary>
    /// Returns either the with or without cursor string, depending on an iternal internal value.
    /// </summary>
    public string GetOutputString()
    {
        Debug.Log(withoutCursor);
        Debug.Log(withCursor);
        Debug.Log(rawString);
        if (useStringWithCursor)
            return withCursor;
        return withoutCursor;
    }

    /// <summary>
    /// Updates both versions of the string by adding the given character to the end.
    /// </summary>
    public void AddChar(string character)
    {
        rawString += character;
        withoutCursor = rawString + withoutCursorSymbol;
        withCursor = rawString + cursorSymbol;
    }

    /// <summary>
    /// Updates both versions of the string by removing the last character.
    /// </summary>
    public void RemoveLastChar()
    {
        rawString = rawString.Remove(rawString.Length - 1);
        withoutCursor = rawString + withoutCursorSymbol;
        withCursor = rawString + withoutCursor;
    }

    public void ToggleUseCursor()
    {
        useStringWithCursor = !useStringWithCursor;
    }
}
