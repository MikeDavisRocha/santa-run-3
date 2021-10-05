using UnityEngine;

public class KunaiSpeed : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    public float speed;
    
    private void Start()
    {
        _rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        _boxCollider2D = GetComponentInChildren<BoxCollider2D>();
    }

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Spike") || collision.gameObject.tag.Equals("Saw"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
