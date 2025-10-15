using UnityEngine;

public class Vampire : MonoBehaviour
{
    [SerializeField] VampireView _vampireView;

    private bool _isVampiring;

    public bool IsVampiring => _isVampiring;

    public void Launch()
    {
        _isVampiring = _vampireView.Launch();
    }
}