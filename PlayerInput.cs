using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private CharacterNumber characterNumber;
    private Player player;    
    [SerializeField] private float jumpVelocity = 20f;
    [SerializeField] private float characterSpeed = 5f;
    [SerializeField] private float gravity = 4f;
    [SerializeField] private float fallMultiplier = 1.5f;
    [SerializeField] private float jumpMultiplier = 1.5f;    

    private void Awake()
    {
        characterNumber = FindObjectOfType<CharacterNumber>();
        player = transform.GetChild(characterNumber.GetUnlockedCharacterNumber()).GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartSlide();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopSlide();
        }
        Run();
        // CharacterFall();        
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(player._boxCollider2D.bounds.center, player._boxCollider2D.bounds.size, 0f, Vector2.down, 1f, player._floorLayerMask);
        return raycastHit2D.collider != null;
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            // player._rigidbody2D.velocity = Vector2.up * jumpVelocity;

            player._rigidbody2D.AddForce(Vector2.up * jumpVelocity * jumpMultiplier, ForceMode2D.Impulse);
            player._animator.SetBool("Jump", true);
            player.soundController.Play("JumpSound");
            player._rigidbody2D.gravityScale = gravity;
        }
    }    

    public void CharacterFall()
    {
        if (!IsGrounded())
        {
            if (player._rigidbody2D.velocity.y < 0)
            {
                player._rigidbody2D.gravityScale = gravity * fallMultiplier;
            }
        }
    }

    public void StartSlide()
    {
        if (IsGrounded())
        {
            // player._animator.applyRootMotion = false;
            player._animator.SetBool("Slide", true);
            player.soundController.Play("SlideSound");
        }
    }

    public void StopSlide()
    {
        // player._animator.applyRootMotion = true;
        player._animator.SetBool("Slide", false);
    }

    public void StartGlide()
    {
        if (!IsGrounded())
        {
            if (characterNumber.GetUnlockedCharacterNumber() == 8)
            {
                player._animator.SetBool("Glide", true);
            }
        }
    }

    public void StopGlide()
    {
        if (!IsGrounded())
        {
            if (characterNumber.GetUnlockedCharacterNumber() == 8)
            {
                player._animator.SetBool("Glide", false);
            }
        }
    }

    public void ThrowKunai()
    {
        if (!IsGrounded())
        {
            if (characterNumber.GetUnlockedCharacterNumber() == 8)
            {
                player._animator.SetBool("Throw", true);
            }
        }
    }

    public void Shoot()
    {
        if (!IsGrounded())
        {
            if (characterNumber.GetUnlockedCharacterNumber() == 9)
            {
                player._animator.SetBool("Shoot", true);
            }
        }
    }   

    private void Run()
    {
        transform.position += transform.right * (characterSpeed * Time.deltaTime);        
    }
}
