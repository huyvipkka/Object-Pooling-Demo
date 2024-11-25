using Unity.VisualScripting;
using UnityEngine;
public class Gun : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 10;
    [SerializeField] protected float acceleration = 7;
    [SerializeField] protected float deceleration = 7;
    [Header("Jumpping")]
    [Header("Shooting")]
    [SerializeField] protected float magnitudeForce = 15;
    [SerializeField] protected float BullPerSecond = 10;
    float ShootTimer = 0;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float moveInput;
    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        Shoot();
        if (Input.GetKey(KeyCode.F))
        {
            rb.AddForce(Vector2.left * 10);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - rb.velocity.x;
        float accelRate = Mathf.Abs(targetSpeed) > 0.01f ? acceleration : deceleration;

        float movement = speedDif * accelRate;
        rb.AddForce(movement * Vector2.right);
    }

    void Shoot()
    {
        ShootTimer += Time.deltaTime;
        if (ShootTimer < 1.0f / BullPerSecond)
            return;
        ShootTimer = 0;
        if (Input.GetMouseButton(0))
        {
            Projectile obj = ObjectPooling.Instance.projectilePool.Get();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 forceDir = (mousePos - (Vector2)transform.position).normalized;

            obj.rb.transform.position = (Vector2)transform.position + forceDir * 0.8f;
            obj.Active();
            obj.rb.AddForce(forceDir * magnitudeForce, ForceMode2D.Impulse);
        }
    }

}