using UnityEngine;

public class RollSnowball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float thrust = 20.0f;
    [SerializeField] float speedOfSpin = 1f;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }

    void FixedUpdate()
    {
        _rigidbody2D.AddForce(transform.right * thrust);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Fall"))
        {
            Destroy(gameObject);
        }
    }
}
