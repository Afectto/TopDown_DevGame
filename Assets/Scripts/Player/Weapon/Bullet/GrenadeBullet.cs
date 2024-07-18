using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : Bullet
{
    private Vector3 targetPosition;
    private float explosionRadius = 5f;

    public void SetTargetPosition(Vector3 target)
    {
        targetPosition = target;
    }

    public override void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            MoveTowardsTarget(targetPosition);
        }
        else
        {
            Explode();
        }
    }

    void MoveTowardsTarget(Vector3 target)
    {
        Vector3 moveDirection = (target - transform.position).normalized * speed * Time.deltaTime;
        transform.position += moveDirection;
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EventManager.Instance.OnDamageTaken.Invoke(collider.gameObject, _damage);
            }
        }
        
        Destroy(gameObject);
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
    }
}
