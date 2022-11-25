using System.Collections;
using System.Collections.Generic;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (!isRadioOn)
        {
            radioLight.color = radioOnColor;
            radioLightMeshRenderer.material.color = radioOnColor;
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
}
