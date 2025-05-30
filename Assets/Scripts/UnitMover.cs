using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
[RequireComponent(typeof(Unit))]

public class UnitMover : MonoBehaviour
{
    private Unit _unit;
    private CharacterAnimator _characterAnimator;

    private void Awake()
    {
        _characterAnimator = GetComponent<CharacterAnimator>();
        _unit = GetComponent<Unit>();
    }
}