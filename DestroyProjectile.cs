using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public GameObject _fireParticlesPrefab;   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Spike") || collision.gameObject.tag.Equals("Saw"))
        {
            GameObject fireParticles = Instantiate(_fireParticlesPrefab);
            fireParticles.transform.parent = collision.transform;
            fireParticles.GetComponent<StartParticles>().StartParticleSystem(collision.transform.position);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
