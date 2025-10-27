using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private List<TextMeshPro> _displays;

    public void Show(float value)
    {
        foreach (TextMeshPro display in _displays)
            display.text = value.ToString();
    }
}