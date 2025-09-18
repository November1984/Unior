using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public void Show(bool value)
    {
        gameObject.SetActive(value);
    }
}