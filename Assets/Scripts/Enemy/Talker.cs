using UnityEngine;

public class Talker : MonoBehaviour
{
    [SerializeField] private float _talkDistance = 2.5f;
    [SerializeField] private Dialogue _dialogue;

    public bool IsTalking { get; private set; }
    public float TalkDistance => _talkDistance;

    public void Talk(bool value)
    {
        _dialogue.Show(value);
        IsTalking = value;
    }
}