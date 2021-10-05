using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float startpos;
    [SerializeField]
    private float speed;

    void Start()
    {
        startpos = transform.position.x;
    }

    void Update()
    {
        Move();                
    }

    private void Move()
    {
        Vector3 newPosition = transform.position + new Vector3(startpos + speed, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
