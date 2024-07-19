using UnityEngine;

public class ShotgunBullet : Bullet
{
    private Vector2 startPoint;
    private void Awake()
    {
        startPoint = transform.position;
    }

    public override void Update()
    {
        base.Update();
        if (Vector2.Distance(startPoint, transform.position) > 7)
        {
            Destroy(gameObject);
        }
    }
}
