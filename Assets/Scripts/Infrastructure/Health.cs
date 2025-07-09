using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float _health = 20f;

    public void Decrease(float value)
    {
        _health -= value;
    }

    public void Increase(float value)
    {
        _health += value;
    }
}