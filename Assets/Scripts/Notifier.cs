using System;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    public event Action<Transform> _isIndoors;
    public event Action _isOutdoors;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IndoorsNotify(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OutdoorsNotify();
    }

    private void IndoorsNotify(Transform obj)
    {
        _isIndoors?.Invoke(obj);
    }

    private void OutdoorsNotify()
    {
        _isOutdoors?.Invoke();
    }
}