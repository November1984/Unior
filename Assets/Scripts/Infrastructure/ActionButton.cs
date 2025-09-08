using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ActionButton : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Affect);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Affect);
    }

    protected virtual void Affect()
    { }
}
