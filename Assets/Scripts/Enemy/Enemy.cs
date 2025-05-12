using UnityEngine;

public class Enemy : MonoBehaviour, IAnimateAble
{
    private bool _isGrounded = true;

    public bool IsGrounded => _isGrounded;
}
