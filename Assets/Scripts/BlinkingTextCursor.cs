using UnityEngine;

public class BlinkingTextCursor
{
    public string withCursor = "|";
    public string withoutCursor = "";
    // gets updated every 0.5 seconds to represent if the output string will contain the cursor
    public bool useStringWithCursor = true;
    public float cursorBlinkFrequency = 0.5f;

    /// <summary>
    /// Returns either the with or without cursor string, depending on an iternal internal value.
    /// </summary>
    public string GetOutputString()
    {
        if (useStringWithCursor)
            return withCursor;
        return withoutCursor;
    }

    /// <summary>
    /// Updates both versions of the string by adding the given character to the end.
    /// </summary>
    public void AddChar(string character)
    {
        withoutCursor += character;
        withCursor = withCursor.Remove(withCursor.Length - 1) + character + "|";
    }

    /// <summary>
    /// Updates both versions of the string by removing the last character.
    /// </summary>
    public void RemoveLastChar()
    {
        withoutCursor += withoutCursor.Remove(withoutCursor.Length - 1);
        withCursor = withCursor.Remove(withCursor.Length - 2) + "|";
    }
}
