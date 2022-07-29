using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerUpDown : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.up;
    public float speed = 5f;

    public AnimationSpriteRenderer spriteRendererUp;
    public AnimationSpriteRenderer spriteRendererDown;
    public AnimationSpriteRenderer spriteRendererDeath;
    private AnimationSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererUp;
    }

    private void Update()
    {
        if(IsFacingUp())
        {
            rigidbody.velocity = new Vector2(0f, speed);
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, -speed);
            SetDirection(Vector2.down, spriteRendererDown);
        }
    }
    private bool IsFacingUp()
    {
        return rigidbody.velocity.y > Mathf.Epsilon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.velocity = new Vector2((Mathf.Sign(rigidbody.velocity.x)), -rigidbody.velocity.y);
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

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
            
        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void Death()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererDeath.enabled = true;

        Invoke(nameof(OnDeathEnded), 1.25f);
    }

    private void OnDeathEnded()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().CheckWinState();
    }
}
