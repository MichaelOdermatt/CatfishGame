using System;
using System.Collections;
using UnityEngine;

public static class ExecuteAfterTime 
{
    public static IEnumerator Exectute(Action action, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        action();   
    }
}
