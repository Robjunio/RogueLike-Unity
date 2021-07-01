using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float Velocity;

        private Input m_InputActions;
        private Vector2 m_Direction;

        private Rigidbody2D m_Rb;

        private void Awake()
        {
            m_InputActions = new Input();
            m_Rb = GetComponent<Rigidbody2D>();

            m_InputActions.Player.Movement.performed += ctx => m_Direction = ctx.ReadValue<Vector2>();
            m_InputActions.Player.Movement.canceled += __ => m_Direction = Vector2.zero;
        }

        private void OnEnable()
        {
            m_InputActions.Enable();
        }

        private void OnDisable()
        {
            m_InputActions.Disable();
        }

        private void Update()
        {
            m_Rb.velocity = m_Direction * Velocity;
        }
    }
}
