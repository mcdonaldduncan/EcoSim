using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    static EcoSim _input;
    Vector3 moveValue;

    float moveModifier = 1;

    private void Awake()
    {
        _input = new EcoSim();
        moveValue = Vector3.zero;
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Move.performed += HandleMovement;
        _input.Player.Move.canceled += HandleMovement;
        _input.Player.Modifier.performed += HandleModifier;
        _input.Player.Modifier.canceled += HandleModifier;
        _input.Player.Modifier.started += HandleModifier;
    }

    private void OnDisable()
    {
        _input.Player.Move.performed -= HandleMovement;
        _input.Player.Move.canceled -= HandleMovement;
        _input.Player.Modifier.performed -= HandleModifier;
        _input.Player.Modifier.canceled -= HandleModifier;
        _input.Player.Disable();
    }

    // Using fixed update to avoid jittery collisions
    private void FixedUpdate()
    {
        if (moveValue == Vector3.zero) return;
        transform.Translate(Time.deltaTime * moveSpeed * moveValue);
    }

    void HandleModifier(InputAction.CallbackContext context)
    {

        moveModifier = context.performed ? 2f : 1f;
        Debug.Log($"Modified to {moveModifier}");
    }

    void HandleMovement(InputAction.CallbackContext context)
    {
        Vector2 current = context.ReadValue<Vector2>();
        moveValue = new Vector3(current.x, 0, current.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
