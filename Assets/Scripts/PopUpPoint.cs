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
    private float _width;

    public event Action<PopUpPoint> Disappeared;

    public float Width => _width;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    public void Update()
    {
        float step = _popUpSpeed * Time.deltaTime;

        if (_downDirection)
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down * _popUpDelay, step);
        else
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up * _popUpDelay, step);
    }

    public void Launch(float value)
    {
        _textMeshPro.text = value.ToString("F0");
        _width = _textMeshPro.preferredWidth;

        if (value < 0)
        {
            _downDirection = true;
            _textMeshPro.color = Color.red;
        }
        else
        {
            _downDirection = false;
            _textMeshPro.color = Color.green;
        }

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
