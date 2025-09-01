using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(TextMeshPro))]
public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    private TextMeshPro _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        Change(_health.CurrentHealth);
    }

    private void OnEnable()
    {
        _health.Changed += Change;
    }

    private void OnDisable()
    {
        _health.Changed -= Change;
    }

    private void Change(float value)
    {
        _textMeshPro.text = $"{_health.CurrentHealth}/{_health.FullHealth}";
    }
}
