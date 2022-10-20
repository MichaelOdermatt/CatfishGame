using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class ConstrainXPos : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    double maxX;

    void Start()
    {
        maxX = rigidbody.position.x;
    }

    void Update()
    {
    }
}
