using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 _maxLimits;
    private Vector2 _minLimits;
    
    public float rotationSpeed = 180f;

    private void Awake()
    {
        _maxLimits = new Vector2(20, 15);
        _minLimits = new Vector2( -20, -15);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        Vector3 newPos = transform.position + movement;

        newPos.x = Mathf.Clamp(newPos.x, _minLimits.x, _maxLimits.x);
        newPos.y = Mathf.Clamp(newPos.y, _minLimits.y, _maxLimits.y);

        transform.position = newPos;
        
        Rotation();
    }

    private void Rotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
