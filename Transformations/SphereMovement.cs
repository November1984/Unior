using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SphereMovement : MonoBehaviour
{
    private void Start()
    {
        var nextPosition = transform.position;

        nextPosition.x = 5f;
        transform.position = nextPosition;
    }

    private void Update()
    {
        const float Step = 0.05f;
        var nextPosition = transform.position;

        nextPosition.z += Step;
        transform.position = nextPosition;
    }
}
