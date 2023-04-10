using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody2D player;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private AudioSource jumpSoundEffect;
    private enum MovementState { idle, running, jumping, falling }
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            player.velocity = new Vector3(0, jumpForce, 0);
        }

        UpdateAnimationState();
    }
    //Animasyonlarýn geçiþlerinin tutulduðu fonksiyon...
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(player.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } 
        else if (player.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    /*Karakterimizin collider box'ýna bir tane daha kutucuk ekliyoruz ancak bu kutucuk 1 milim aþaðýda oluyor ve sadece "Terrain" ile
    etkileþime girdiði zaman true döndürüyor. Böylelikle diðer objelere dokunduðumuz zaman yerde olup olmadýðýmýz kontrol edilmeyecek.
    */
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
