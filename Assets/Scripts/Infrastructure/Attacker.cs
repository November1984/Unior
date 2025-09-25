using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    [SerializeField, Range(0, 100)] private float _force = 10f;
    [SerializeField, Min(0)] private float _attackDelay = 1f;
    [SerializeField, Min(0)] private float _attackRadius = 0.8f;

    private IDamageable _attackedUnit;
    private Coroutine _coroutine;

    public bool IsAttacking { get; private set; }

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = _attackRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable unit))
        {
            _attackedUnit = unit;
            IsAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsAttacking = collision.TryGetComponent(out IDamageable unit))
        {
            _attackedUnit = null;
            IsAttacking = false;
        }
    }

    public void Attack()
    {
        _dialogue.Show(true);
        _coroutine = StartCoroutine(MakeAttack());
    }

    public void StopAttack()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _dialogue.Show(false);
        IsAttacking = false;
    }

    private IEnumerator MakeAttack()
    {
        var wait = new WaitForSecondsRealtime(_attackDelay);

        while (true)
        {
            _attackedUnit?.Health.Decrease(_force);

            yield return wait;
        }
    }
}