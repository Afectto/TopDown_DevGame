using System.Collections;
using UnityEngine;

public abstract class PickupBuff : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer skin; 
    protected IStats Stats;

    public virtual void Initialize(IStats stats)
    {
        Stats = stats;
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke();
            Destroy(gameObject);
        }
    }

    protected abstract void Invoke();
}