using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _displays;

    private bool _isStarted;
    private double _startValue;

    private void Start()
    {
        _isStarted = false;
    }

    private void Update()
    {
        if (_isStarted)
        {
            _startValue = Math.Round((_startValue - Time.deltaTime)*100) / 100f;
            
            foreach (GameObject display in _displays)
            {
                TextMeshPro disp = display.GetComponent<TextMeshPro>();
                disp.text = _startValue.ToString();
            }
        }
    }

    public void Launch(float value)
    {
        _isStarted = true;
        _startValue = value;
    }
}
