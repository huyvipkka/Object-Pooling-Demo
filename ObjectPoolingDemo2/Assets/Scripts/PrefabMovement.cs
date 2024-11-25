using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PrefabMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 direction;
    float speed = 3;
    private Camera cam;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        direction = new Vector3(Random.Range(0, 1), Random.Range(0, 1), 0).normalized;
        rb.velocity = direction * speed;
    }

    private void Update()
    {
        if (!IsInView(transform.position))
        {
            gameObject.SetActive(false);
        }
    }
    private bool IsInView(Vector3 worldPosition)
    {
        Vector3 viewportPoint = cam.WorldToViewportPoint(worldPosition);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
               viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
               viewportPoint.z > 0;
    }
}
