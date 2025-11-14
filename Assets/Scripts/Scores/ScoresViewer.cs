using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoresViewer : MonoBehaviour
{
    [SerializeField] private ScoresCounter _scoresCounter;
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _scoresCounter.Changed += Show;
    }

    private void OnDisable()
    {
        _scoresCounter.Changed -= Show;
    }

    private void Show(int value)
    {
        _textMeshProUGUI.text = value.ToString();
    }
}