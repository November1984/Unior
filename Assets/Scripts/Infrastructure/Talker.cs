using UnityEngine;

[RequireComponent(typeof(InputReader))]

public class Talker : MonoBehaviour
{
    [SerializeField] private float _talkDistance = 2.5f;

    private InputReader _inputReader;

    public bool IsTalking { get; private set; }
    public float TalkDistance => _talkDistance;

    private void Awake()
    {
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

    private void TalkingNotify(bool value)
    {
        IsTalking = value;
    }
}