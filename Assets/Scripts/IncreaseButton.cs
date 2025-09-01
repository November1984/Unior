using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class IncreaseButton : MonoBehaviour
{
    [SerializeField] private float _increaseValue = 10f;
    [SerializeField] private Health _health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Increase);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Increase);
    }

    private void Increase()
    {
        _health.Increase(_increaseValue);
    }
}
