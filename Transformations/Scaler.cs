using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 0.005f;

    private void Update()
    {
        transform.localScale += Vector3.one * _scaleSpeed;
    }
}
