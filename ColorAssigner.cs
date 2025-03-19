using UnityEngine;

public class ColorAssigner : MonoBehaviour
{
    private void OnEnable()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Color randomColor = new Color(
                Random.value, 
                Random.value,
                Random.value 
            );

            renderer.material.color = randomColor;
        }
    }
}
