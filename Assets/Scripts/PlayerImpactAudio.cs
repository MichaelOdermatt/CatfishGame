using UnityEngine;

public class PlayerImpactAudio : MonoBehaviour
{
    private float maxVelocity = 13;
    private float minVelocity = 2.5f;
    public AudioSource impactAudioSource;
    [SerializeField]
    private AudioClip[] keyboardSounds;
    [SerializeField]
    private AudioClip[] standardImpactSounds;

    public void PlayImpactSound(float impactVelocityMagnitude, int collisionObjectLayer)
    {
        AudioClip sound;
        if (collisionObjectLayer == 10)
            sound = SetAudioClipToKeyboardSound();
        else 
            sound = SetAudioClipToImpactSound();

        if (impactVelocityMagnitude < minVelocity)
            return;

        if (impactVelocityMagnitude >= maxVelocity)
            impactAudioSource.volume = 1;
        else
            impactAudioSource.volume = (impactVelocityMagnitude - minVelocity) / maxVelocity;

        impactAudioSource.PlayOneShot(sound);
    }

    private AudioClip SetAudioClipToKeyboardSound()
    {
        int soundIndex = Random.Range(0, standardImpactSounds.Length);    
        return keyboardSounds[soundIndex];
    }

    private AudioClip SetAudioClipToImpactSound()
    {
        int soundIndex = Random.Range(0, standardImpactSounds.Length);    
        return standardImpactSounds[soundIndex];
    }
}
