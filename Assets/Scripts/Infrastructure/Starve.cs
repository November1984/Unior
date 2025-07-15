using UnityEngine;

public class Starve : MonoBehaviour
{
    [SerializeField] protected float _satiety = 20f;

    public void Decrease(float value)
    {
        _satiety += value;
    }

    public void Increase(float value)
    {
        _satiety -= value;
    }
}