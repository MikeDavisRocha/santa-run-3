using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    [SerializeField] float speedOfSpin = 1f;

    void Update()
    {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
}
