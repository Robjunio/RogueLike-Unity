using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float damage;

    [SerializeField] protected float attackDelay;
    protected float attackDelayTimer;
    
    protected Transform Player;
    protected Rigidbody2D rb2D;
    protected Animator m_anim;
    private float m_CurrentHealth;
    
    private enum AnimList
    {
        WalkingUp,
        WalkingDown,
        WalkingLeft,
        WalkingRight
    }
    
    private AnimList m_currentAnimation;
    protected virtual void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag(Tags.Player.ToString()).transform;
        m_anim = GetComponent<Animator>();
        m_CurrentHealth = MaxHealth;
    }

    
    protected virtual void FixedUpdate()
    {
        AnimateEnemy();
    }
    
    private void AnimateEnemy()
    {
        if (Mathf.Abs(rb2D.velocity.x) > Mathf.Abs(rb2D.velocity.y))
        {
            if (rb2D.velocity.x > 0.1f)
            {
                ChangeAnimation(AnimList.WalkingRight);
            }
            else
            {
                ChangeAnimation(AnimList.WalkingLeft);
            }
        }
        else
        {
            if (rb2D.velocity.y > 0.1f)
            {
                ChangeAnimation(AnimList.WalkingUp);
            }
            else
            {
                ChangeAnimation(AnimList.WalkingDown);
            }
        }
    }

    private void ChangeAnimation(AnimList newAnimation)
    {
        if (m_currentAnimation == newAnimation) return;

        m_currentAnimation = newAnimation;
        m_anim.Play(newAnimation.ToString());
    }
    public virtual void ReceiveHit(float _damage)
    {
        m_CurrentHealth -= _damage;

        if (m_CurrentHealth <= 0)
        {
            StartDeath();
        }
    }

    private void StartDeath()
    {
        Destroy(gameObject);
    }
}
