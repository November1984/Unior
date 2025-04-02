using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private List<TextMeshPro> _displays;

    private bool _isStarted;
    private double _startValue;

    private void Start()
    {
        _isStarted = false;
    }

    private void Update()
    {
        const float decimalShift = 100f;
        
        if (_isStarted)
        {
            _startValue = Math.Round((_startValue - Time.deltaTime)*decimalShift) / decimalShift;
            
            foreach (TextMeshPro display in _displays)
                display.text = _startValue.ToString();
        }
    }

    public void Launch(float value)
    {
        _isStarted = true;
        _startValue = value;
    }
    
    public void Stop()
    {
        _isStarted = false;
    }
}
