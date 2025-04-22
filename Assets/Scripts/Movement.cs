using UnityEngine;

public class Movement : MonoBehaviour
{
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis(_horizontal), Input.GetAxis(_vertical));

        transform.Translate(Time.deltaTime * direction);
    }
}