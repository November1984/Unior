using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Renderer>(out Renderer renderer))
        {
            if (renderer.material.color != Color.red)
            {
                renderer.material.color = Color.red;
                if (collision.gameObject.TryGetComponent<Destroyer>(out Destroyer destroyer))
                    destroyer.StartSelfDestroy();
            }
        }
    }
}
