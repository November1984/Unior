using System;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    public event Action ObjectIndoored;
    public event Action ObjectOutdoored;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thieft>(out Thieft fool))
            IndoorsNotify();
    }

    private void OnTriggerExit2D(Collider2D collision) => OutdoorsNotify();

    private void IndoorsNotify() => ObjectIndoored?.Invoke();

    private void OutdoorsNotify() => ObjectOutdoored?.Invoke();
}