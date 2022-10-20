using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyValue : MonoBehaviour, IKeyFunction
{
    public bool isLetter;
    public string Value;
    public string AltValue;

    public void Action(UpdateScreen updateScreen)
    {
        if (isLetter && updateScreen.isCapsLockOn)
        {
            updateScreen.AddCharacter(AltValue);
        } else
        {
            updateScreen.AddCharacter(Value);
        }
    }
}
