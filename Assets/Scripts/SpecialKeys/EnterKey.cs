using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterKey : MonoBehaviour, IKeyFunction
{
    void IKeyFunction.Action(UpdateScreen updateScreen)
    {
        updateScreen.ClearScreen();
    }
}
