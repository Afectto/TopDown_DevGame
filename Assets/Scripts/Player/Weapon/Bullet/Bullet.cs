
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float speed = 7f;
    
    protected float Damage;
    
    private Vector3 _moveDirection;
    
    public void SetDamage(float damage)
    {
        Damage = damage;
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
        if (!Utils.IsPositionInsideRectangle(transform.position))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EventManager.Instance.OnDamageTaken?.Invoke(other.gameObject, Damage);
            Destroy(gameObject);
        }
    }
}

