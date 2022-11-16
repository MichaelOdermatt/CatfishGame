using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PointToPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private float LookSpeed;
    [SerializeField]
    private float LookIntensity;

    private void Update()
    {
        var dir = (Target.position * LookIntensity) - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, LookSpeed * Time.deltaTime);
    }
}
