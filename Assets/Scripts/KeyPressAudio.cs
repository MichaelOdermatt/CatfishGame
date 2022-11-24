using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource keyPressSource;
    [SerializeField]
    private AudioClip[] keyPressSounds;

    public void PlayKeyPressSound()
    {
        int soundIndex = Random.Range(0, keyPressSounds.Length);
        keyPressSource.PlayOneShot(keyPressSounds[soundIndex]);
    }
}
