using UnityEngine;

public class MonitorAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip accessGranted;
    [SerializeField]
    private AudioClip accessDenied;

    public void PlayAccessGrantedSound()
    {
        audioSource.clip = accessGranted;
        audioSource.Play();
    }

    public void PlayAccessDeniedSound()
    {
        audioSource.clip = accessDenied;
        audioSource.Play();
    }
}
