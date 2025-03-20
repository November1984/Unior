using UnityEngine;

public class ColorAssigner
{
    public Color GetRandomColor(Renderer renderer)
    {
        Color randomColor;

        if (renderer != null)
        {
            randomColor = new Color(
                Random.value,
                Random.value,
                Random.value
            );
            return randomColor;
        }

        return Color.white;
    }
}
