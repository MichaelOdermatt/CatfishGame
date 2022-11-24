using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] jumpSounds;
    [SerializeField]
    private AudioSource jumpSource;

    public void PlayJumpSound()
    {
        int soundIndex = Random.Range(0, jumpSounds.Length);
        jumpSource.PlayOneShot(jumpSounds[soundIndex]);
    }
}
