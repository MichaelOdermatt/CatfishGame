using System;
using System.Collections;
using UnityEngine;

public static class ExecuteAfterTime 
{
    /// <summary>
    /// Must be started as a coroutine
    /// </summary>
    public static IEnumerator Exectute(Action action, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        action();   
    }
}
