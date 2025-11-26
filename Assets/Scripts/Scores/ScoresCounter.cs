using System;
using UnityEngine;

public class ScoresCounter : MonoBehaviour
{
    private int _scores;

    public event Action<int> Changed;
    
    public int Scores => _scores;

    public void AddScore()
    {
        _scores++;
        Changed?.Invoke(_scores);
    }

    public void ResetScores()
    {
        _scores = 0;
        Changed?.Invoke(_scores);
    }
}