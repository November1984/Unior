using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private void Start()
    {
        const float Step = 5f;

        var nextPosition = transform.position;
        
        nextPosition.z -= Step;
        transform.position = nextPosition;
    }

    private void Update()
    {
        const float ScaleStep = 0.005f;
        const float RotationStep = 0.5f;
        const float MovementStep = 0.05f;

        var nextPosition = transform.position;
        var nextScale = transform.localScale;

        nextPosition.x -= MovementStep;
        transform.position = nextPosition;

        transform.localScale = new Vector3 (nextScale.x + ScaleStep, nextScale.y + ScaleStep, nextScale.z + ScaleStep);

        transform.Rotate(transform.up, RotationStep);
    }
}
