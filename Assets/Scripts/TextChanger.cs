using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private string _startValue = "Здесь какой-то текст";
    [SerializeField] private string _endValue = "Some text was here";
    [SerializeField] private string _addValue = ", or will be";
    [SerializeField] private ScrambleMode _scrambleMode = ScrambleMode.All;
    [SerializeField] private bool _reachText = false;

    private Sequence _sequence;
    
    private void Awake()
    {
        _text = GetComponent<Text>();
        _sequence = DOTween.Sequence();
        
        _sequence
            .Append(ScrambleText())
            .Append(TypeText())
            .Append(AddText())
            .SetLoops(-1, LoopType.Restart);
    }

    private void Start()
    {
        _sequence.Play();
    }

    private Tween ScrambleText()
    {
        return _text.DOText(_endValue, _duration, _reachText, _scrambleMode)
        .SetLoops(2, LoopType.Yoyo);
    }

    private Tween TypeText()
    {
         return _text.DOText(_startValue, _duration)
            .SetLoops(3, LoopType.Yoyo);
    }

    private Tween AddText()
    {
        return _text.DOText(_addValue, _duration)
            .SetRelative()
            .SetLoops(2, LoopType.Yoyo);
    }
}