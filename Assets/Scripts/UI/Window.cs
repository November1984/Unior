using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowsGroup;
    [SerializeField] private Button _actionButton;

    protected CanvasGroup WindowsGroup => _windowsGroup;
    protected Button ActionButton => _actionButton;

    private void OnEnable ()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        WindowsGroup.alpha = 0f;
        ActionButton.interactable = true;
    }

    public void Close()
    {
        WindowsGroup.alpha = 1f;
        ActionButton.interactable = false;
    }

    protected abstract void OnButtonClick();
}