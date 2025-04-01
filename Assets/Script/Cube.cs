using UnityEngine;

public class Cube : MonoBehaviour
{
    private void OnEnable()
    {
        if (TryGetComponent<Renderer>(out Renderer renderer))
            renderer.material.color = Color.blue;
    }
}