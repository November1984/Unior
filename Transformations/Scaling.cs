using UnityEngine;

public class Scaling : MonoBehaviour
{
    private void Update()
    {
        transform.localScale += Vector3.one * 0.005f;
    }
}
