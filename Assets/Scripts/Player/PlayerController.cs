using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.DialogeSystem.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Movement")]
    public float speed = 5f;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public DialogeUI DialogeUI;
    private DialogueHintUI dialogueHintUI;

    private string currentAnimation;
    public IInteractable Interactable { get; set; }
    private bool onCillisionWithTileMap = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueHintUI = FindObjectOfType<DialogueHintUI>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (onCillisionWithTileMap) return;
        if (DialogeUI.IsOPen)
        {
            ResetToIdleAnimation();
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;

        UpdateAnimation(moveX, moveY);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interactable != null)
            {
                dialogueHintUI.HideHint();
                Interactable.Interact(this);
                ResetToIdleAnimation();
            }
        }
        if (DialogeUI.IsOPen) return;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void ResetToIdleAnimation()
    {
        if (currentAnimation == "Walk_Back" || currentAnimation == "Idle_back")
        {
            PlayAnimation("Idle_back");
        }
        else if (currentAnimation == "WalkForward" || currentAnimation == "Idle_Forward")
        {
            PlayAnimation("Idle_Forward");
        }
        else if (currentAnimation == "Walk_Left" || currentAnimation == "Idle_Right")
        {
            PlayAnimation("Idle_Right");
            spriteRenderer.flipX = true;
        }
        else if (currentAnimation == "Walk_Right" || currentAnimation == "Idle_Right")
        {
            PlayAnimation("Idle_Right");
            spriteRenderer.flipX = false;
        }
        else
        {
            // Якщо невідома анімація - встановлюємо дефолтний idle
            PlayAnimation("Idle_Forward");
        }
    }

    void UpdateAnimation(float moveX, float moveY)
    {
        if (moveX == 0 && moveY == 0)
        {
            if (currentAnimation == "Walk_Back")
                PlayAnimation("Idle_back");
            else if (currentAnimation == "WalkForward")
                PlayAnimation("Idle_Forward");
            else if (currentAnimation == "Walk_Left")
            {
                PlayAnimation("Idle_Right");
                spriteRenderer.flipX = true;
            }
            else if (currentAnimation == "Walk_Right")
            {
                PlayAnimation("Idle_Right");
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                if (moveX > 0)
                {
                    PlayAnimation("Walk_Right");
                    spriteRenderer.flipX = false;
                }
                else
                {
                    PlayAnimation("Walk_Left");
                    spriteRenderer.flipX = false;
                }
            }
            else
            {
                if (moveY > 0)
                    PlayAnimation("Walk_Back");
                else
                    PlayAnimation("WalkForward");
            }
        }
    }

    public void Teleport(Vector2 position) => transform.position = position;

    public void ForceMovement(Vector2 direction, float duration)
    {
        StartCoroutine(ForcedMovementCoroutine(direction, duration));
    }

    private IEnumerator ForcedMovementCoroutine(Vector2 direction, float duration)
    {
        float elapsed = 0f;
        PlayAnimation("WalkForward");
        while (elapsed < duration)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        PlayAnimation("Idle_Forward");
    }

    void PlayAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return; // Уникнення повторного виклику однієї анімації
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
