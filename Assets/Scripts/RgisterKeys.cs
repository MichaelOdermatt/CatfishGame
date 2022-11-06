using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Gets key inputs and calls key function methods
/// </summary>
public class RgisterKeys : MonoBehaviour
{
    [SerializeField]
    private UpdateScreen updateScreen;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        IKeyFunction keyFunction;
        gameObject.TryGetComponent(out keyFunction);

        if (keyFunction == null)
            return;

        keyFunction.Action(updateScreen);
    }
}
