using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DecreaseButton : MonoBehaviour
{
    [SerializeField] private float _decreaseValue = 10f;
    [SerializeField] private Health _health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Decrease);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Decrease);
    }

    private void Decrease()
    {
        _health.Decrease(_decreaseValue);
    }
}
