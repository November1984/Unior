using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputData;
    [SerializeField] Counter _counter;

    private void OnEnable()
    {
        _counter.CounterUpdated += DisplayCounter;
    }

    private void OnDisable()
    {
        _counter.CounterUpdated += DisplayCounter;
    }

    protected void Start()
    {
        _outputData.text = "";
    }

    public void DisplayCounter()
    {   
        _outputData.text = _counter.Value.ToString("");
    }

}