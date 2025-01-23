using UnityEngine;

public class Rotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(transform.up, 0.5f);
    }
}
