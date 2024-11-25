using UnityEngine;
using UnityEngine.Pool;
public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;
    private ObjectPool<Projectile> _pool;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _pool = ObjectPooling.Instance.projectilePool;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _pool.Release(this);
        }
    }

    public void Active()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        gameObject.SetActive(true);
    }
}