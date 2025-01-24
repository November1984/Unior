using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _speed = 0.005f;

    private void Update()
    {
        transform.localScale += Vector3.one * _speed;
var position = Vector3.up.normalized;
         Debug.Log(position);
    }
}
