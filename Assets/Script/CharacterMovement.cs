using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] CharacterController cc;
    [SerializeField] Animator animator;

    private void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        Vector2 v2MovementDirection = playerInput.actions.FindActionMap("PlayerRunning").FindAction("Movement").ReadValue<Vector2>();
        Vector3 movementDirection = new Vector3(v2MovementDirection.x, 0, v2MovementDirection.y);

        Vector3 localDirection = transform.InverseTransformDirection(movementDirection);
        animator.SetFloat("RunningX", localDirection.x);
        animator.SetFloat("RunningZ", localDirection.z);

        cc.Move(movementDirection * speed*Time.deltaTime);
    }
}
