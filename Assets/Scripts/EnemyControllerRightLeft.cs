using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerRightLeft : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.right;
    public float speed = 5f;

    public AnimationSpriteRenderer spriteRendererLeft;
    public AnimationSpriteRenderer spriteRendererRight;
    public AnimationSpriteRenderer spriteRendererDeath;
    private AnimationSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererRight;
    }

    private void Update()
    {
        if(IsFacingRight())
        {
            rigidbody.velocity = new Vector2(speed, 0f);
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            rigidbody.velocity = new Vector2(-speed, 0f);
            SetDirection(Vector2.left, spriteRendererLeft);
        }
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody.velocity.x)), transform.localScale.y);
    }
        
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimationSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;
            
        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void Death()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathEnded), 1.25f);
    }

    private void OnDeathEnded()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }
}
