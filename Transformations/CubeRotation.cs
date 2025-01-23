using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private void Update()
    {
        const float Step = 0.5f;

        transform.Rotate(transform.up, Step);
    }
}
