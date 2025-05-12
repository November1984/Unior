using UnityEngine;

public interface IMoveAble
{
    public float JumpSpeed { get; }
    public float RunSpeed { get; }
    public Rigidbody2D Rigidbody { get; }
    public Transform Transform { get; }
    public bool IsOnGround { get; }
}