using System;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    public event Action<Thieft> ObjectIndoored;
    public event Action<Thieft> ObjectOutdoored;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thieft>(out Thieft fool))
            IndoorsNotify(fool);
    }

    private void OnTriggerExit2D(Collider2D collision) => OutdoorsNotify();

    private void IndoorsNotify(Thieft fool) => ObjectIndoored?.Invoke(fool);

    private void OutdoorsNotify(Thieft fool = null) => ObjectOutdoored?.Invoke(fool);
}