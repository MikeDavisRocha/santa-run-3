using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask _floorLayerMask;
    public Rigidbody2D _rigidbody2D;
    public BoxCollider2D _boxCollider2D;
    public Animator _animator;
    public SoundController soundController;
    public UIManager uiManager;
    public GameManager gameManager;
    private CharacterNumber characterNumber;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        soundController = FindObjectOfType<SoundController>();
        uiManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
        characterNumber = FindObjectOfType<CharacterNumber>();
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Spikes") || collision.gameObject.tag.Equals("Saw") || collision.gameObject.tag.Equals("GolemSnowball"))
        {
            _animator.applyRootMotion = true;
            _animator.SetBool("Die", true);
            soundController.Play("DeathSound");
            uiManager.ChangeScreenElementsState(false);
            uiManager.ChangeGameOverPanelState(true);
            _boxCollider2D.enabled = false;
            gameManager.GameOver();
            soundController.Stop("GameplaySound");
            soundController.Play("GameOverSound");
        }
        if (collision.gameObject.tag.Equals("Fall"))
        {
            _animator.SetBool("Die", true);
            soundController.Play("DeathSound");
            uiManager.ChangeScreenElementsState(false);
            uiManager.ChangeGameOverPanelState(true);
            _boxCollider2D.enabled = false;
            gameManager.GameOver();
            soundController.Stop("GameplaySound");
            soundController.Play("GameOverSound");
        }
        if (collision.gameObject.tag.Equals("Floor"))
        {
            _animator.SetBool("Jump", false);
            if (characterNumber.GetUnlockedCharacterNumber() == 8)
            {
                _animator.SetBool("Throw", false);
                _animator.SetBool("Glide", false);
            }
            if (characterNumber.GetUnlockedCharacterNumber() == 9)
            {
                _animator.SetBool("Shoot", false);
            }
        }
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}
