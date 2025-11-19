using UnityEngine;

public interface IObstacle
{
    public Collider2D Collider2D { get; }

    public void SetActive(bool value);
    public void SetPosition(Vector3 position);
}