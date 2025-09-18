using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class DialogueShower : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.IsTalked += Show;
    }

    private void OnDisable()
    {
        _inputReader.IsTalked -= Show;
    }

    public void Show(bool value)
    {
        _dialogue.Show(value);
    }
}
