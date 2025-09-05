using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class PopUpPoint : MonoBehaviour
{
    [SerializeField] private float _popUpSpeed = 100f;
    [SerializeField] private float _popUpDelay = 1.5f;

    private bool _downDirection = true;
    private TextMeshPro _textMeshPro;
    private Coroutine _coroutine;

    public event Action<PopUpPoint> Disappeared;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    public void Update()
    {
        float step = _popUpSpeed * Time.deltaTime;
        Vector3 newPosition;

        if (_downDirection)
            newPosition = transform.position + Vector3.down * _popUpDelay;
        else
            newPosition = transform.position + Vector3.up * _popUpDelay;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
    }

    public void Launch(float value)
    {
        _textMeshPro.text = value.ToString("F0");

        _downDirection = value < 0;
        _textMeshPro.color = _downDirection?Color.red:Color.green;

        _coroutine = StartCoroutine(StartCountDown(_popUpDelay));
    }

    private IEnumerator StartCountDown(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        yield return wait;

        StopCoroutine(_coroutine);
        Disappeared?.Invoke(this);
    }
}
