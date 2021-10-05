using UnityEngine;

public class Candy : MonoBehaviour
{
    private CandiesController candiesController;
    private SoundController soundController;
    private Animator animator;

    private void Awake()
    {
        candiesController = FindObjectOfType<CandiesController>();
        soundController = FindObjectOfType<SoundController>();
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            animator.SetBool("Move", true);
            candiesController.AddCandy();
            soundController.Play("CandySound");
            Invoke("ResetCandy", 1f);
        }
    }

    private void ResetCandy()
    {
        animator.SetBool("Move", false);
    }
}
