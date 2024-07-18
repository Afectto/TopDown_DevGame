using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private Vector3 _moveDirection;
    protected float _damage;
    public float speed = 7f;
    
    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void SetDirection(Vector3 moveDirection)
    {
        _moveDirection = moveDirection.normalized;
    }
    
    public virtual void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.position += _moveDirection * speed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EventManager.Instance.OnDamageTaken.Invoke(other.gameObject, _damage);
        }
    }
}

