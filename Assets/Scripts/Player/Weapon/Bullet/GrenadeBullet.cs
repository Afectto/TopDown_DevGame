using UnityEngine;

public class GrenadeBullet : Bullet
{
    [SerializeField]private float explosionRadius = 2f;
    private Vector3 _targetPosition;

    public void SetTargetPosition(Vector3 target)
    {
        _targetPosition = target;
    }

    public override void Update()
    {
        if (transform.position != _targetPosition)
        {
            MoveToTarget(_targetPosition);
        }
        else
        {
            Explode();
        }
    }

    void MoveToTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EventManager.Instance.OnDamageTaken?.Invoke(collider.gameObject, Damage);
            }
        }
        
        Destroy(gameObject);
    }
    
}
