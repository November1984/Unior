using System;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    public event Action<Transform> IsIndoors;
    public event Action IsOutdoors;

    private void OnTriggerEnter2D(Collider2D collision) => IndoorsNotify(collision.transform);

    private void OnTriggerExit2D(Collider2D collision) => OutdoorsNotify();

    private void IndoorsNotify(Transform obj) => IsIndoors?.Invoke(obj);

    private void OutdoorsNotify() => IsOutdoors?.Invoke();
}