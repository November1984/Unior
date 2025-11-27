using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public abstract class ActionButton : MonoBehaviour
{
    private Button _button;
    public event Action Clicked;

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

    protected void Affect()
    {
        Clicked?.Invoke();
    }
}