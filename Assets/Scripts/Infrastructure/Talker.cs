using UnityEngine;

[RequireComponent(typeof(Starve))]
[RequireComponent(typeof(InputReader))]

public class Talker : MonoBehaviour
{
    [SerializeField] private float _talkDistance = 2.5f;

    private Starve _starve;
    private InputReader _inputReader;

    public bool IsTalking { get; private set; }
    public float TalkDistance => _talkDistance;

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