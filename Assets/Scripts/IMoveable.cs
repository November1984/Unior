using UnityEngine;

public interface IMovable
{
    public bool IsOnGround { get; }
    public float JumpSpeed { get; }
    public float RunSpeed { get; }
    public Rigidbody2D Rigidbody { get; }
    public Transform Transform { get; }
}