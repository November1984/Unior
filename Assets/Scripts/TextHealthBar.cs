using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class TextHealthBar : Healthbar
{
    private TextMeshPro _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        Width = _textMeshPro.preferredWidth;
    }

    protected override void Change(float value, float delta)
    {
        _textMeshPro.text = $"{_health.Current}/{_health.Max}";

        base.Change(value, delta);
    }
}
