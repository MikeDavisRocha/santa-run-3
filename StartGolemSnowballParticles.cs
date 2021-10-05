using UnityEngine;

public class StartGolemSnowballParticles : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void StartParticles(Vector2 touchPosition)
    {
        particleSystem.transform.position = touchPosition;
        particleSystem.Play();
        Destroy(transform.parent.gameObject, 1f);
    }
}
