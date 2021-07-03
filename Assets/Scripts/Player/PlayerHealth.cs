using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    private float m_currentHealth;

    private void Awake()
    {
        m_currentHealth = MaxHealth;
    }

    public void ReceiveHit(float _damage)
    {
        m_currentHealth -= _damage;

        if (m_currentHealth <= 0)
        {
            StartDeath();
        }
    }

    private void StartDeath()
    {
        Destroy(gameObject);
    }
}
