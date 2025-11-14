using System;
using UnityEngine;

public class ScoresCounter : MonoBehaviour
{
    public event Action<int> Changed;
    
    private int _scores;

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