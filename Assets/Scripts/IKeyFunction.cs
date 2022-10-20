using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface representing a key and its function
/// </summary>
public interface IKeyFunction 
{
    /// <summary>
    /// The function of a the key when it is pressed
    /// </summary>
    /// <param name="updateScreen"></param>
    public void Action(UpdateScreen updateScreen);
}
