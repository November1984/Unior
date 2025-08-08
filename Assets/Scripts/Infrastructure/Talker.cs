using UnityEngine;

[RequireComponent(typeof(Starve))]
[RequireComponent(typeof(InputReader))]

public class Talker : MonoBehaviour
{
    public bool IsTalking { get; private set; }

    private Starve _starve;
    private InputReader _inputReader;

    public float TalkDistance => 1f;

    private void Awake()
    {
        _starve = GetComponent<Starve>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.IsTalked += TalkingNotify;
    }

    private void OnDisable()
    {
        _inputReader.IsTalked -= TalkingNotify;
    }

    public void Feed(float value)
    {
        _starve.Decrease(value);
    }

    public void Talk()
    {
        // _dialog = new();

        // _dialog.Show(transform.position, value);
    }

    private void TalkingNotify(bool value)
    {
        IsTalking = value;
    }
}