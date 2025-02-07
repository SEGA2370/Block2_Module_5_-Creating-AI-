using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [Header ("Walk")]
    Vector2 playerInput;
    float moveSpeed;
    [SerializeField]  float walkSpeed;
    [SerializeField] private float rotationDuration = 0.3f;
    GameObject playerParent;
    Animator animator;

    private bool isDead = false;

    private void Start()
    {
        playerParent = GameObject.FindWithTag("PlayerParent");
        animator = GetComponent<Animator>();
    }

    public void Move(InputAction.CallbackContext _context)
    {
        if (isDead) return;
        if (_context.phase == InputActionPhase.Performed) // Key pressed
        {
            playerInput = _context.ReadValue<Vector2>();
        }
        else if (_context.phase == InputActionPhase.Canceled) // Key released
        {
            playerInput = Vector2.zero;
        }
    }

    private void Update()
    {
        if(isDead) return;

        MovePlayer();
        RotatePlayer();

        if (playerInput == Vector2.zero)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsWalkingBackward", false);
        }
        else
        {
            moveSpeed = walkSpeed;

            if (playerInput.y > 0) // Moving forward
            {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsWalkingBackward", false);
            }
            else if (playerInput.y < 0) // Moving backward
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsWalkingBackward", true);
            }
        }
    }

    void MovePlayer()
    {
        Vector3 moveVector = playerInput.x * Vector3.right + playerInput.y * Vector3.forward;
        moveVector.Normalize();

        playerParent.transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
    }

    private void RotatePlayer()
    {
        if (playerInput != Vector2.zero)
        {
            // Calculate the target rotation based on movement direction
            Vector3 targetDirection = new Vector3(playerInput.x, 0f, playerInput.y);
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Use DoTween for smooth rotation
            playerParent.transform.DORotateQuaternion(targetRotation, rotationDuration);
        }
    }
}
