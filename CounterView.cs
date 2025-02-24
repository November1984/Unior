using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputData;

    protected void Start()
    {
        _outputData.text = "";
    }

    public void DisplayCounter(int value)
    {
        _outputData.text = value.ToString("");
    }

}