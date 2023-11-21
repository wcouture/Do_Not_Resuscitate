using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Regular move speed
    public float sprintSpeedMultiplier = 2.0f; // Sprint speed multiplier
    public float collisionOffset = 0.05f;
    private Vector2 movementInput;
    public ContactFilter2D movementFilter;
    private Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private float originalMoveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            float currentSpeed = moveSpeed;

<<<<<<< Updated upstream
=======
            // Animation stuff goes here
            animator.SetFloat("VerticalMovement", movementInput.y);
            animator.SetFloat("HorizontalMovement", movementInput.x);

>>>>>>> Stashed changes
            // Check if the player is holding down the sprint key (Left Shift)
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                currentSpeed *= sprintSpeedMultiplier;
            }

            int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                currentSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + movementInput * currentSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnSprint(InputValue sprintValue)
    {
        // You can toggle the sprint by setting a boolean flag or handle sprint differently
        // Here's a simple example:
        if (sprintValue.isPressed)
        {
            moveSpeed = originalMoveSpeed * sprintSpeedMultiplier;
        }
        else
        {
            moveSpeed = originalMoveSpeed;
        }
    }
}