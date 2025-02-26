using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputData;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Updated += DisplayCounter;
    }

    private void OnDisable()
    {
        _counter.Updated += DisplayCounter;
    }

    protected void Start()
    {
        _outputData.text = "";
    }

    public void DisplayCounter(int value)
    {   
        _outputData.text = value.ToString("");
    }

}