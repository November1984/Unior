using UnityEngine;

public class ColorAssigner
{
    public Color GetRandomColor()
    {
        Color randomColor = new Color(
            Random.value,
            Random.value,
            Random.value
        );
        return randomColor;
    }
}
