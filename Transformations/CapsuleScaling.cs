using UnityEngine;

public class CapsuleScaling : MonoBehaviour
{
    private void Start()
    {
        var nextPosition = transform.position;

        nextPosition.y = 5f;
        transform.position = nextPosition;
    }

    private void Update()
    {
        const float Step = 0.005f;
        var nextScale = transform.localScale;

        transform.localScale = new Vector3 (nextScale.x + Step, nextScale.y + Step, nextScale.z + Step);
    }
}
