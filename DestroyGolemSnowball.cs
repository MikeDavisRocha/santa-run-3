using UnityEngine;

public class DestroyGolemSnowball : MonoBehaviour
{
    private StartGolemSnowballParticles startGolemSnowballParticles;

    private void Awake()
    {
        startGolemSnowballParticles = FindObjectOfType<StartGolemSnowballParticles>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor") || collision.gameObject.tag.Equals("Player"))
        {
            startGolemSnowballParticles.StartParticles(transform.position);
            Destroy(gameObject);        
        }
    }
}
