using UnityEngine;

public class MoveSky : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += transform.right * (speed * Time.deltaTime);
    }
}
