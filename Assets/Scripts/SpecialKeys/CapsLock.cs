using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsLock : MonoBehaviour, IKeyFunction
{

    [SerializeField]
    private Light CapsLockLight;

    public void Action(UpdateScreen updateScreen)
    {
        bool newCapsLockStatus = !updateScreen.isCapsLockOn;
        updateScreen.isCapsLockOn = newCapsLockStatus;
        CapsLockLight.enabled = newCapsLockStatus;
    }
}
