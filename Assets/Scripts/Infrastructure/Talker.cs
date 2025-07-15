using UnityEngine;

[RequireComponent(typeof(Starve))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Dialog))]

public class Talker : MonoBehaviour
{
    public bool IsTalking { get; private set; }

    private Starve _starve;
    private InputReader _inputReader;
    private Dialog _dialog;

    public float TalkDistance => 1f;

    private void Awake()
    {
        _starve = GetComponent<Starve>();
        _inputReader = GetComponent<InputReader>();
        _dialog = GetComponent<Dialog>();
    }

    private void OnEnable()
    {
        _inputReader.IsTalking += TalkingNotify;
    }

    private void OnDisable()
    {
        _inputReader.IsTalking -= TalkingNotify;
    }

    public void Feed(float value)
    {
        _starve.Decrease(value);
    }

    public void ShowDialog()
    {
        _dialog.Show(transform.position);
    }

    private void TalkingNotify(bool value)
    {
        IsTalking = value;
    }
}