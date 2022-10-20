using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceKey : MonoBehaviour, IKeyFunction
{
    public void Action(UpdateScreen updateScreen)
    {
        updateScreen.RemoveLastChar();
    }
}
