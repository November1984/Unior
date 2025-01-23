using UnityEngine;

public class Movement : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(transform.forward * 0.05f);
    }
}
