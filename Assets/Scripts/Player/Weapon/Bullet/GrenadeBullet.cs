using UnityEngine;

public class GrenadeBullet : Bullet
{
    [SerializeField]private float explosionRadius = 5f;
    private Vector3 _targetPosition;

    public void SetTargetPosition(Vector3 target)
    {
        _targetPosition = target;
    }

    public override void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) > 0.1f)
        {
            MoveTowardsTarget(_targetPosition);
        }
        else
        {
            Explode();
        }
    }

    void MoveTowardsTarget(Vector3 target)
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
