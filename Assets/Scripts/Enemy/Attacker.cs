using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;
    [SerializeField, Range(0, 100)] private float _force = 10f;
    [SerializeField] private float _attackDelay = 1f;

    private IDamageable _attackedUnit;
    private Coroutine _coroutine;

    public bool IsAttacking { get; private set; }

    public void Attack(IDamageable unit)
    {
        IsAttacking = true;
        _attackedUnit = unit;

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
            yield return wait;

            _attackedUnit.Health.ChangeValue(-_force);
        }
    }
}