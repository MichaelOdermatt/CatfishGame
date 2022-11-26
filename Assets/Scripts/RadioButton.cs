using UnityEngine;

public class RadioButton : MonoBehaviour
{
    [SerializeField]
    private Light radioLight;
    [SerializeField]
    private MeshRenderer radioLightMeshRenderer;
    [SerializeField]
    private AudioSource radioAudioSource;

    [SerializeField]
    private Color radioOnColor;
    [SerializeField]
    private Color radioOffColor;

    private bool isRadioOn = false;
    private float[] randomPitchValues = new float[3]
    {
        0.9f,
        1,
        1.25f,
    };

    private void OnCollisionEnter(Collision collision)
    {
        if (!isRadioOn)
        {
            radioLight.color = radioOnColor;
            radioLightMeshRenderer.material.color = radioOnColor;
            RandomizePitch();
            radioAudioSource.Play();    
            isRadioOn = true;
        } else
        {
            radioLight.color = radioOffColor;
            radioLightMeshRenderer.material.color = radioOffColor;
            radioAudioSource.Stop();    
            isRadioOn = false;
        }
    }

    private void RandomizePitch()
    {
        int soundIndex = Random.Range(0, randomPitchValues.Length);
        radioAudioSource.pitch = randomPitchValues[soundIndex];
    }
}
