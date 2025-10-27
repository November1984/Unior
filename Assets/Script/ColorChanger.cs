using UnityEngine;

public class ColorChanger
{
    public void PaintRed(Renderer coloredRenderer)
    {
        coloredRenderer.material.color = Color.red; 
    }
}