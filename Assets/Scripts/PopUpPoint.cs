using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class PopUpPoint : MonoBehaviour
{
    [SerializeField, Min(0.01f)] private float _popUpSpeed = 100f;
    [SerializeField] private float _popUpTime = 1f;

    private bool _downDirection = true;
    private bool _isRuning = false;
    private TextMeshPro _textMeshPro;
    private Coroutine _finishRoutine;
    private Coroutine _moveRoutine;

    public event Action<PopUpPoint> Disappeared;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    public void Launch(float value)
    {
        _textMeshPro.text = value.ToString("F0");

        _downDirection = value < 0;
        _textMeshPro.color = _downDirection ? Color.red : Color.green;

        _finishRoutine = StartCoroutine(StartCountDown(_popUpTime));

        if (_finishRoutine != null)
            _moveRoutine = StartCoroutine(StartMove(_popUpTime));
    }

    private IEnumerator StartMove(float delay)
    {
        Vector3 newPosition;
        float step = _popUpSpeed * delay;
        float slowDown = 1 / _popUpSpeed;

        var wait = new WaitForSecondsRealtime(slowDown);

        if (_downDirection)
            newPosition = transform.position + Vector3.down * step;
        else
            newPosition = transform.position + Vector3.up * step;

        _isRuning = true;

        while (_isRuning)
        {
            yield return wait;

            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * _popUpSpeed);
        }
    }

    private IEnumerator StartCountDown(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        yield return wait;

        _isRuning = false;

        StopCoroutine(_finishRoutine);
        StopCoroutine(_moveRoutine);
        Disappeared?.Invoke(this);
    }
}
