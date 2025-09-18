using UnityEngine;

public class Talker : MonoBehaviour
{
    [SerializeField] private float _talkDistance = 2.5f;
    [SerializeField] private Dialogue _dialogue;
    [SerializeField, Range(0, 100)] private float _talkCost = 10f;

    public bool IsTalking { get; private set; }
    public float TalkDistance => _talkDistance;
    public float TalkCost => _talkCost;

    public float Talk(bool value)
    {
        _dialogue.Show(value);
        IsTalking = value;

        return -_talkCost;
    }
}