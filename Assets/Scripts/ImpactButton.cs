using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ImpactButton : MonoBehaviour
{
    [SerializeField] private float _impactValue = 0f;
    [SerializeField] private Health _health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Impact);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Impact);
    }

    private void Impact()
    {
        _health.Change(_impactValue);
    }
}
