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
    GameObject playerParent;

    private void Start()
    {
        playerParent = GameObject.FindWithTag("PlayerParent");
    }

    public void Move(InputAction.CallbackContext _context)
    {
        playerInput = _context.ReadValue<Vector2>();
    }

    private void Update()
    {
        MovePlayer();

        if(playerInput != Vector2.zero)
        {
            moveSpeed = walkSpeed;
        }
    }

    void MovePlayer()
    {
        Vector3 moveVector = playerInput.x * Vector3.right + playerInput.y * Vector3.forward;
        moveVector.Normalize();

        playerParent.transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
    }
}
